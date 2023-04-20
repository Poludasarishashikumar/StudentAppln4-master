using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentAppln4.Models
{
    public class Login
    {
        [Key]
        [Display(Name = "ID")]
        [Required(ErrorMessage = "You need to enter Valid Id!")]
        public int Id { get; set; }
        [Display(Name = "Password")]

        [Required(ErrorMessage = "Password is Unfilled!")]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is Required!")]
        public string Email { get; set; }

        public string Token { get; set; }
        public int RecStatus { get; set; } = 1;
    }
}