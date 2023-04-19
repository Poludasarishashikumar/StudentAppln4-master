using StudentAppln4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace StudentAppln4.Controllers
{
    public class Student1Controller : Controller
    {
        private ApplicationDbContext _context;
        public static int varstatic = 0;
        //public static string userdata;
        
        public Student1Controller()
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




        public ActionResult Index()
        {
            return View();
        }
        

        //[HttpPost]
        //public ActionResult Form(Student1 student)
        //{
        //    using(var client=new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44325/api/PostStudents"); ;
        //        var postTask = client.PostAsJsonAsync<Student1>("PostStudents", student);
        //        postTask.Wait();
        //        var result = postTask.Result;
        //        if(result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("ViewDetails",student);
        //        }
        //    }
        //    ModelState.AddModelError(string.Empty, "Error occured in this action");
        //    return View("Form", student);

        //}






        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Form(Student1 student1)
        //{
        //    var ErrId = _context.Student1s.Where(x => x.RecStatus == 1).ToList();
        //    foreach (var k in ErrId)
        //    {
        //        if (string.Equals(student1.StudentId1, k.StudentId1))
        //        {
        //            return RedirectToAction("IDErr");
        //        }
        //        if(string.Equals(student1.Email, k.Email))
        //        {
        //            //userdata = k.Email;
        //             return RedirectToAction("MailErr");
        //            //return Content("<script type='text/javascript'>alert('Email already exists');</script>");
                    

        //        }
        //    }



        //    foreach(var j in ErrId)
        //    {
        //         varstatic = -1;
        //        if(varstatic<j.StudentId)
        //        {
        //            varstatic = j.StudentId;
        //        }
        //    }



        //    varstatic++;
        //    string K = varstatic.ToString();
        //    //student1.StudentId1 = "19C31A" + (student1.StudentId).ToString();
        //    student1.StudentId1 = String.Concat("19C31A"+K);

            
        //    _context.Student1s.Add(student1);

        //    _context.SaveChanges();
            
        //    return RedirectToAction("ViewDetails","Student1");
        //}




        public ActionResult IDErr()
        {
            return View();
        }




        public ActionResult MailErr()
        {
            return View();
        }




        public ActionResult ViewDetails(Student1 students)
        {
            var stu = _context.Student1s.Where(x => x.RecStatus == 1).ToList();
            

            //List<Student1> student1s = new List<Student1>();

            return View(stu);
            //return View();
        }




        [HttpGet]
        public ActionResult Edit(int id,int flag)
        {
            if (flag == 0)
            {
                ViewBag.IsEditMode = true;
            }
            else
            {
                ViewBag.IsEditMode = false;
            }
                //var cat1 = _context.Student1s.Find(id);
                //var cat2 = _context.Student1s.FirstOrDefault(u => u.StudentId == id);
                var cat3 = _context.Student1s.SingleOrDefault(u => u.StudentId == id);
                if (cat3 == null)
                {
                    return HttpNotFound();
                }

                return View("Edit", cat3);
            
                
            
            
        }
        [HttpGet]
        public ActionResult View2(int id)
        {

            //var cat1 = _context.Student1s.Find(id);
            //var cat2 = _context.Student1s.FirstOrDefault(u => u.StudentId == id);
            var cat3 = _context.Student1s.SingleOrDefault(u => u.StudentId == id);
            if (cat3 == null)
            {
                return HttpNotFound();
            }

            return View("View2", cat3);
        }




        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Student1 student1)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var stIn = _context.Student1s.Single(s => s.StudentId == student1.StudentId);
        //        //student1.StudentId = s.StudentId;
        //        var ErrId = _context.Student1s.ToList();

        //        int countEmail = 0;
        //        foreach (var k in ErrId)
        //        {

        //            if (string.Equals(student1.Email, k.Email))
        //            {
        //                //if (string.Equals(student1.StudentId1, k.StudentId1))
        //                //{

        //                //    //return RedirectToAction("IDErr");
        //                //    continue;

        //                //}
        //                //else
        //                //{
        //                //    countEmail++;
        //                //}
        //                countEmail++;
        //            }
        //        }
        //        if (countEmail > 1)
        //        {
        //            return RedirectToAction("MailErr");
        //        }




        //        stIn.StudentId1 = student1.StudentId1;
        //        //stIn.StudentId1 = "19C31A" + (student1.StudentId).ToString();

        //        stIn.StudentId = student1.StudentId;

        //        stIn.FirstName = student1.FirstName;
        //        stIn.LastName = student1.LastName;
        //        stIn.Email = student1.Email;
        //        //var ErrId = _context.Student1s.ToList();
        //        //foreach (var k in ErrId)
        //        //{
        //        //    if (string.Equals(student1.StudentId1, k.StudentId1))
        //        //    {
        //        //        return RedirectToAction("IDErr");
        //        //    }
        //        //    if (string.Equals(student1.Email, k.Email))
        //        //    {
        //        //        return RedirectToAction("MailErr");
        //        //    }
        //        //}
        //        _context.Student1s.AddOrUpdate(student1);
        //        //_context.Entry(student1).State = EntityState.Modified;
        //        _context.SaveChanges();
        //        return RedirectToAction("ViewDetails", student1);
        //    }
        //    return View(student1);
        //}

        //[HttpPost]
        //public ActionResult Edit(Student1 student1)
        //{
        //    //Student1 student = null;

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44325/api/Student1");
        //        //HTTP GET
        //        var responseTask = client.GetAsync("Student1?StudentId=" + student1.StudentId.ToString());
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<Student1>();
        //            readTask.Wait();

        //            student1 = readTask.Result;
        //        }
        //    }

        //    return RedirectToAction("ViewDetails",student1);
        //}
















        [HttpGet]
        public ActionResult Delete(int id)
        {
            var student = _context.Student1s.FirstOrDefault(x => x.StudentId == id);
            _context.Student1s.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("ViewDetails");
        }




        public JsonResult CheckEmailavail(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var search = _context.Student1s.Where(x => x.Email == userdata).FirstOrDefault();
            if(search!=null)
            {
                //return this.Json(1, JsonRequestBehavior.AllowGet);
                return Json(1);
            }
            else
            {
                //return this.Json(0, JsonRequestBehavior.AllowGet);
                return Json(0);
            }
        }
        [HttpGet]
        public ActionResult ViewAll(int Id)
        {
            /*var stu = _context.Student1s.Where(x => x.RecStatus == 1 && x.StudentId==Id).ToList();*/


            //List<Student1> student1s = new List<Student1>();

            return View();
            //return View();
        }
        [HttpGet]
        public ActionResult Form2(int id)
        {
            var stu = _context.Student1s.Where(x => x.RecStatus == 1 && x.StudentId == id);
            //var stu = id;
            return View("Form2",stu);
        }
        
        public ActionResult Form2(Student1 student)
        {
            //var stIn = _context.Student1s.Single(s => s.StudentId == student.StudentId);
            var stIn = student.StudentId;
            return View(stIn);
            //return Json("true", JsonRequestBehavior.AllowGet);
        }
        public JsonResult getStudent(int id)
        {
            List<Student1> students = new List<Student1>();
            students = _context.Student1s.Where(x => x.StudentId == id).ToList();
            return Json(students, JsonRequestBehavior.AllowGet);
        }
    }
}