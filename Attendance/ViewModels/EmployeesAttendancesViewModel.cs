using Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance.ViewModels
{
    public class EmployeesAttendancesViewModel
    {
        public List<Employee> Employees { get; set; }
        public List<AttendanceLog> AttendanceLogs { get; set; }
        public string TimeInInput { get; set; }
        public string TimeOutInput { get; set; }

    }
}