using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentAppln4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentAppln4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        private ApplicationDbContext _context;

        public LoginController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Student1
        public ActionResult Form()
        {
            ViewBag.Message = "Details";

            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(Login login)
        {
            _context.Logins.Add(login);
            _context.SaveChanges();
             return RedirectToAction("ViewDetails", "Login");
           // return View();
        }
        public ActionResult ViewDetails(Login login)
        {
            var log = _context.Logins.ToList();


            //List<Student1> student1s = new List<Student1>();

            return View(log);
            //return View();
        }
    }
}