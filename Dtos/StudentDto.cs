using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentAppln4.Dtos
{
    public class StudentDto
    {
        [Key]
        public int StudentId { get; set; }//valida
        public string StudentId1 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public int RecStatus { get; set; } = 1;
    }
}