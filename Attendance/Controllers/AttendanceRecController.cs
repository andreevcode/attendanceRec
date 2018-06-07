using Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Attendance.ViewModels;

namespace Attendance.Controllers
{

    public class AttendanceRecController : Controller
    {
        private ApplicationDbContext _context;
        readonly TimeSpan BREAK_START = new TimeSpan(12, 0, 0);
        readonly TimeSpan BREAK_FINISH = new TimeSpan(13, 0, 0);

        public AttendanceRecController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: AttendanceRec
        public ActionResult Index()
        {
            var employees = _context.Employees.ToList();
            var viewModel = new EmployeesAttendancesViewModel()
            {
                Employees = employees,
                Date = null
            };
            return View(viewModel);
        }

        [Route("AttendanceRec/log/")]
        public ActionResult Log()
        {
            var attendanceLog = _context.AttendanceLogs.Include(v => v.Employee).ToList();
            return View(attendanceLog);
        }

        [Route("AttendanceRec/jobtime/")]
        public ActionResult JobTime()
        {
            var attendanceJobTimes = _context.AttendanceJobTimes
                .Include(v => v.Employee)
                //.Include(v => v.Department)
                .ToList();
            return View(attendanceJobTimes);
        }

        [HttpPost]
        [SubmitButtonSelector(Name = "SaveTimeIn")]
        public ActionResult SaveTimeIn(EmployeesAttendancesViewModel viewModel, string EmpId)
        {
            var newAttendanceRecord = new AttendanceLog()
            {
                TimeIn = TimeSpan.Parse(viewModel.TimeInInput),
                EmployeeId = int.Parse(EmpId),
                Date = viewModel.Date
            };
            _context.AttendanceLogs.Add(newAttendanceRecord);
            _context.SaveChanges();
            return RedirectToAction("Index", "AttendanceRec");
        }

        [HttpPost]
        [SubmitButtonSelector(Name ="SaveTimeOut")]
        public ActionResult SaveTimeOut(EmployeesAttendancesViewModel viewModel, string EmpId)
        {
            var newAttendanceRecord = new AttendanceLog()
            {
                TimeOut = TimeSpan.Parse(viewModel.TimeOutInput),
                EmployeeId = int.Parse(EmpId),
                Date = viewModel.Date
            };
            //Calculate JobTime
            GetJobTime(newAttendanceRecord);
            _context.AttendanceLogs.Add(newAttendanceRecord);
            _context.SaveChanges();
            return RedirectToAction("Index", "AttendanceRec");
        }

        public ActionResult Report()
        {
            return RedirectToAction("Index", "AttendanceRec");
        }

        private void GetJobTime(AttendanceLog newRec)
        {
            // Get last TimeIn record for the Day and the Employee
            var latestTimeIn = _context.AttendanceLogs
                    .Where(x => (x.EmployeeId == newRec.EmployeeId) && (x.Date == newRec.Date) && (x.TimeIn != null))
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault()
                    .TimeIn;

            var ExtraBrakeTime = GetBrakeTime((TimeSpan)newRec.TimeOut, (TimeSpan)latestTimeIn);

            //Try find last JobTime Record if Employee has already came in and came out
            var LastDayAttendanceRec = _context.AttendanceJobTimes
                    .Where(x => x.EmployeeId == newRec.EmployeeId && x.Date == newRec.Date && newRec.Date != null)
                    .FirstOrDefault();
            if (LastDayAttendanceRec != null)
            {
                TimeSpan UpdatedJobTime = LastDayAttendanceRec.JobTime + (TimeSpan)newRec.TimeOut - (TimeSpan)latestTimeIn - ExtraBrakeTime;
                var rec = _context.AttendanceJobTimes.SingleOrDefault(x => x.Id == LastDayAttendanceRec.Id);
                {
                    rec.JobTime = UpdatedJobTime;
                    rec.DayFinishTime = (TimeSpan)newRec.TimeOut;
                    rec.IsJobTimeNotEnough = (UpdatedJobTime < TimeSpan.FromHours(8)) ? true : false;
                    rec.IsJobTimeTooMuch = (UpdatedJobTime > TimeSpan.FromHours(9)) ? true : false;
                }
            }
            else
            {
                TimeSpan newJobTime = (TimeSpan)newRec.TimeOut - (TimeSpan)latestTimeIn - ExtraBrakeTime;
                var newJobTimeRecord = new AttendanceJobTime()
                {
                    Date = (DateTime)newRec.Date,
                    JobTime = newJobTime,
                    EmployeeId = newRec.EmployeeId,
                    DayStartTime = (TimeSpan)latestTimeIn,
                    DayFinishTime = (TimeSpan)newRec.TimeOut,
                    IsLate = ((TimeSpan)latestTimeIn > TimeSpan.FromHours(8)) ? true : false,
                    IsJobTimeNotEnough = (newJobTime < TimeSpan.FromHours(8)) ? true: false,
                    IsJobTimeTooMuch = (newJobTime > TimeSpan.FromHours(9)) ? true : false,
                };
                _context.AttendanceJobTimes.Add(newJobTimeRecord);
            }

            //DB update
            _context.SaveChanges();
        }

        //Find break time between lastTimeIn and TimeOut (current)
        private TimeSpan GetBrakeTime(TimeSpan TimeOut, TimeSpan LastTimeIn)
        {
            if (TimeOut <= BREAK_START || (TimeOut>=BREAK_FINISH && LastTimeIn>=BREAK_FINISH)) return new TimeSpan(0, 0, 0);
            else if (LastTimeIn < BREAK_START && TimeOut <= BREAK_FINISH) return TimeOut - BREAK_START;
            else if (LastTimeIn < BREAK_FINISH && LastTimeIn > BREAK_START && TimeOut > BREAK_FINISH) return BREAK_FINISH - LastTimeIn;
            else return new TimeSpan(1, 0, 0);
        }
    }
}