using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentAppln4.Controllers.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using StudentAppln4.Models;
using ActionNameAttribute = System.Web.Http.ActionNameAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace StudentAppln4.Controllers
{
    public class ConsumeController : Controller
    {
        // GET: Consume
        HttpClient client = new HttpClient();
        public ActionResult ViewDetails2()
        {
            List<Student1> list = new List<Student1>();
            client.BaseAddress = new Uri("https://localhost:44325/api/Student1");
            var response = client.GetAsync("Student1");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Student1>>();
                display.Wait();
                list = display.Result;

            }


            return View(list);
        }
        [HttpPost]
        public ActionResult Create(Student1 student)
        {
            client.BaseAddress = new Uri("https://localhost:44325/api/Student1");
            var response = client.PostAsJsonAsync<Student1>("Student1", student);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult Details(int id)
        {
            Student1 e = null;
            client.BaseAddress = new Uri("https://localhost:44325/api/Student1");
            var response = client.GetAsync("Student1?studentId=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Student1>();
                display.Wait();
                e = display.Result;
            }
            return View("Details",e);
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int id)
        {
            Student1 e = null;
            client.BaseAddress = new Uri("https://localhost:44325/api/Student1");
            var response = client.GetAsync("Student1?StudentId=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Student1>();
                display.Wait();
                e = display.Result;
            }
            return View("Edit",e);
        }
        [HttpPost]
        public ActionResult Edit(Student1 e)
        {
            client.BaseAddress = new Uri("https://localhost:44325/api/Student1");
            var response = client.PutAsJsonAsync<Student1>("Student1", e);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("ViewDetails2",e);
            }

            return View("Edit");
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult Delete(int id)
        {
            Student1 e = null;
            client.BaseAddress = new Uri("https://localhost:44325/api/Student1");
            var response = client.GetAsync("Student1?studentId=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Student1>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44325/api/Student1");
            var response = client.DeleteAsync("Student1/" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Delete");
        }
    }
}