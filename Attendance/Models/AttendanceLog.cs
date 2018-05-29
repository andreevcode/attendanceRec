using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models
{
    public class AttendanceLog
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public TimeSpan? TimeIn { get; set; }

        public TimeSpan? TimeOut { get; set; }

        public DateTime? Date { get; set; }
    }
}