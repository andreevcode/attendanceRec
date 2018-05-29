using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Code { get; set; }
        public Department DepartmentParent { get; set; }
        public int? DepartmentId { get; set; }
    }
}