using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Patronymic { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Position { get; set; }

        public Employee Chief { get; set; }

        public int? EmployeeId { get; set; }
    }
}