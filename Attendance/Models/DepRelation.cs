using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models
{
    public class DepRelation
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Department Department { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}