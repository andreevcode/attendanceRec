using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models
{
    public class TimeShedule
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public TimeSpan SheduleStartTime { get; set; }

        [Required]
        public TimeSpan SheduleFinishTime { get; set; }

        [Required]
        public TimeSpan BreakStartTime { get; set; }

        [Required]
        public TimeSpan BreakFinishTime { get; set; }

    }
}