using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance.Models
{
    public class TimeShedule
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public TimeSpan SheduleStartTime { get; set; }
        public TimeSpan SheduleFinishTime { get; set; }
        public TimeSpan BreakStartTime { get; set; }
        public TimeSpan BreakFinishTime { get; set; }

    }
}