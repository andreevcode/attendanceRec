using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance.Models
{
    public class AttendanceJobTime
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public TimeSpan DayStartTime { get; set; }
        public TimeSpan DayFinishTime { get; set; }
        public TimeSpan JobTime { get; set; }
        public DateTime Date { get; set; }
        public bool IsLate { get; set; }
        public bool IsJobTimeNotEnough { get; set; }
        public bool IsJobTimeTooMuch { get; set; }
    }
}