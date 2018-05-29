using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models
{
    public class Timelog
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FinishDate { get; set; }

        public Employee Employee { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}