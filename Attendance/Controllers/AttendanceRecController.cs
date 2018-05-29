using Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
            var employees = _context.Employees.ToList();
            return View(employees);
        }
    }
}