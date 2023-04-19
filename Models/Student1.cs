using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StudentAppln4.Models;

namespace StudentAppln4.Models
{
    public class Student1
    {
        [Key]
        [Display(Name = "ID")]
        [Required(ErrorMessage = "You need to enter Valid StudentId!")]
        
        public int StudentId { get; set; }
        [Display(Name = "Student ID")]
        [Required(ErrorMessage = "You need to enter Valid StudentId!")]

       //[IDExists(ErrorMessage ="Already Exists")]
        public string StudentId1 { get; set; }
        [Display(Name = "FirstName")]
        [Required(ErrorMessage ="FirstName is Unfilled")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets are allowed!")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets are allowed!")]
        [Required(ErrorMessage = "Last name is Unfilled!")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email is Required!")]
        public string Email { get; set; }
        public int RecStatus { get; set; } = 1;
    }
}