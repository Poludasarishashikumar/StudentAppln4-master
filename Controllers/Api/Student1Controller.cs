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
    [EnableCors("*","*","*")]
    public class Student1Controller : ApiController
    {
        public static int varapi=0;
        private ApplicationDbContext _context;
        public Student1Controller()
        {
            _context = new ApplicationDbContext();
        }
        [Route("api/GetStudents")]
        [HttpGet]
        public IEnumerable<StudentDto> GetStudent1s()
        {
            return _context.Student1s.Where(x => x.RecStatus == 1).ToList().Select(Mapper.Map<Student1, StudentDto>);
        }

        [Route("api/GetStudents/{id}")]
        [HttpGet]
        public HttpResponseMessage GetStudent1(int id)
        {
            var student = _context.Student1s.Where(x => x.RecStatus == 1).FirstOrDefault(c => c.StudentId == id);
            if (student != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, student);
            }
            else
            {
                //return Ok(Mapper.Map<Student1, StudentDto>(student));
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id= " + id.ToString() + " not found");
            }
        }





        [Route("api/PostStudents")]
        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage CreateStudent(StudentDto studentDto)
        {
            try
            {
                
                    var sr = _context.Student1s.Where(x => x.RecStatus == 1).ToList();
                    foreach (var a in sr)
                    {
                        if (String.Equals(a.StudentId1, studentDto.StudentId1))
                        {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with StudentId= " + studentDto.StudentId1.ToString() + " already exists");
                        }
                        if (String.Equals(a.Email, studentDto.Email))
                        {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Email= " + studentDto.Email.ToString() + " already exists");
                        }
                    }

                foreach (var j in sr)
                {
                    varapi = -1;
                    if (varapi < j.StudentId)
                    {
                        varapi = j.StudentId;
                    }
                }



                varapi++;
                string K = varapi.ToString();
                //student1.StudentId1 = "19C31A" + (student1.StudentId).ToString();
                studentDto.StudentId1 = String.Concat("19C31A" + K);












                //if (!ModelState.IsValid)
                //{
                //    return BadRequest();
                //}
                var student = Mapper.Map<StudentDto, Student1>(studentDto);
                _context.Student1s.Add(student);
                _context.SaveChanges();
                studentDto.StudentId = student.StudentId;
                var message = Request.CreateResponse(HttpStatusCode.Created,"created sucessfully");
               // message.Headers.Location = new Uri(Request.RequestUri + student.StudentId.ToString());
                //return Created(new Uri(Request.RequestUri + "/" + student.StudentId), studentDto);
                return message;

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }



        [Route("api/UpdateStudents/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(int id, StudentDto studentDto)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    throw new HttpResponseException(HttpStatusCode.NotFound);
                //}
                var student1InDb = _context.Student1s.Where(x => x.RecStatus == 1).FirstOrDefault(c => c.StudentId == id);
                //var student1InDb = _context.Student1s.Single(c => c.StudentId == id);


                var ErrId = _context.Student1s.Where(x => x.RecStatus == 1 ).ToList();
                int countEmail = 0;
                foreach (var k in ErrId)
                {

                    if (string.Equals(studentDto.Email, k.Email))
                    {
                        if (id == k.StudentId)
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
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Email= " + studentDto.Email.ToString() + " already exists");
                }















                if (student1InDb == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id = " + id.ToString() + " not found to update");
                }
                else
                {
                    //Mapper.Map(studentDto, student1InDb);
                    //student1InDb.StudentId = studentDto.StudentId;
                    student1InDb.FirstName = studentDto.FirstName;
                    student1InDb.LastName = studentDto.LastName;
                    student1InDb.Email = studentDto.Email;


                    _context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK,"id= "+id.ToString()+"updated sucessfully");
                }
            }

            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }




        [Route("api/DeleteStudents/{id}")]

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {


                var student = _context.Student1s.Where(x => x.RecStatus == 1).FirstOrDefault(c => c.StudentId == id);
                if (student == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id= " + id.ToString()+" Not Found");
                }
                else
                {
                    _context.Student1s.Remove(student);
                    _context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK,"id= "+id.ToString()+" deleted sucessfully");
                }
            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }

        }




    }
}
