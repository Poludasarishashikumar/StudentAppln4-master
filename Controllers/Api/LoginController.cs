using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentAppln4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentAppln4.Dtos;
using AutoMapper;
using System.Web.Http.Cors;

namespace StudentAppln4.Controllers.Api
{
    [EnableCors("*", "*", "*")]
    public class LoginController : ApiController
    {
       // public static int varapi = 0;
        private ApplicationDbContext _context;
        public LoginController()
        {
            _context = new ApplicationDbContext();
        }
        [Route("api/GetLogin")]
        [HttpGet]
        public IEnumerable<LoginDto> GetLogin()
        {
            return _context.Logins.Where(x => x.RecStatus == 1).ToList().Select(Mapper.Map<Login, LoginDto>);
        }

        [Route("api/GetLogin/{id}")]
        [HttpGet]
        public HttpResponseMessage GetLogin(int id)
        {
            var login = _context.Logins.Where(x => x.RecStatus == 1).FirstOrDefault(c => c.Id == id);
            if (login != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, login);
            }
            else
            {
                //return Ok(Mapper.Map<Student1, StudentDto>(student));
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Login with Id= " + id.ToString() + " not found");
            }
        }





        [Route("api/PostLogin")]
        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage CreateLogin(LoginDto loginDto)
        {
            try
            {

                var sr = _context.Logins.Where(x => x.RecStatus == 1).ToList();
                foreach (var a in sr)
                {
                    if (String.Equals(a.Id, loginDto.Id))
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id= " + loginDto.Id.ToString() + " already exists");
                    }
                    if (String.Equals(a.Email, loginDto.Email))
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Email= " + loginDto.Email.ToString() + " already exists");
                    }
                }

               












                //if (!ModelState.IsValid)
                //{
                //    return BadRequest();
                //}
                var student = Mapper.Map<LoginDto, Login>(loginDto);
                _context.Logins.Add(student);
                _context.SaveChanges();
                
                var message = Request.CreateResponse(HttpStatusCode.Created, "created sucessfully");
                // message.Headers.Location = new Uri(Request.RequestUri + student.StudentId.ToString());
                //return Created(new Uri(Request.RequestUri + "/" + student.StudentId), studentDto);
                return message;

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }



        [Route("api/UpdateLogin/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(int id, LoginDto loginDto)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    throw new HttpResponseException(HttpStatusCode.NotFound);
                //}
                var login = _context.Logins.Where(x => x.RecStatus == 1).FirstOrDefault(c => c.Id == id);
                //var student1InDb = _context.Student1s.Single(c => c.StudentId == id);


                var ErrId = _context.Logins.Where(x => x.RecStatus == 1).ToList();
                int countEmail = 0;
                foreach (var k in ErrId)
                {

                    if (string.Equals(loginDto.Email, k.Email))
                    {
                        if (id == k.Id)
                        {


                            continue;



                        }
                        else
                        {
                            countEmail++;
                        }

                    }
                }
                if (countEmail > 0)
                {
                    countEmail = 0;
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Email= " + loginDto.Email.ToString() + " already exists");
                }















                if (login == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Login with Id = " + id.ToString() + " not found to update");
                }
                else
                {
                    //Mapper.Map(studentDto, student1InDb);
                    //student1InDb.StudentId = studentDto.StudentId;
                    login.Password = loginDto.Password;
                   
                    login.Email = loginDto.Email;


                    _context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "id= " + id.ToString() + "updated sucessfully");
                }
            }

            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }




        [Route("api/DeleteLogin/{id}")]

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {


                var login = _context.Logins.Where(x => x.RecStatus == 1).FirstOrDefault(c => c.Id == id);
                if (login == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id= " + id.ToString() + " Not Found");
                }
                else
                {
                    _context.Logins.Remove(login);
                    _context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "id= " + id.ToString() + " deleted sucessfully");
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }

        }
    }
}
