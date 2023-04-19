using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentAppln4.Models
{
    public class IDExists : ValidationAttribute
    {
            private ApplicationDbContext _context;
        public IDExists()
        {
            _context = new ApplicationDbContext();
        }
        protected void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
        //var Id = (Student1)validationContext.ObjectInstance;
            var k = _context.Student1s.ToList();

            foreach(var l in k)
            {
                if (string.Equals(l.StudentId1, value))
                {
                    return new ValidationResult("Id is Already used");
                }
                
            }
                    return ValidationResult.Success;

            
        }
    }
}