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
            //var employees = _context.Employees.ToList();
            //return View(employees);

            var attendanceLogs = _context.AttendanceLogs.Include(v => v.Employee).ToList();
            var employees = _context.Employees.ToList();
            var viewModel = new EmployeesAttendancesViewModel()
            {
                Employees = employees,
                AttendanceLogs= attendanceLogs
            };

            return View(viewModel);
        }

        [Route("AttendanceRec/log/")]
        public ActionResult Log()
        {
            var attendanceLog = _context.AttendanceLogs.Include(v => v.Employee).ToList();
            return View(attendanceLog);
        }

        [HttpPost]
        [SubmitButtonSelector(Name = "SaveTimeIn")]
        public ActionResult SaveTimeIn(EmployeesAttendancesViewModel viewModel, string EmpId, string Date)
        {
            var newAttendanceRecord = new AttendanceLog()
            {
                TimeIn = TimeSpan.Parse(viewModel.TimeInInput),
                EmployeeId = int.Parse(EmpId)
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
                EmployeeId = int.Parse(EmpId)
            };
            _context.AttendanceLogs.Add(newAttendanceRecord);
            _context.SaveChanges();
            return RedirectToAction("Index", "AttendanceRec");
        }
    }
}