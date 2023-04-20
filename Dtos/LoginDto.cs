using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentAppln4.Dtos
{
    public class LoginDto
    {
        
       [Key]
        public int Id { get; set; }
        
        public string Password { get; set; }
        
        public string Email { get; set; }
        public string Token { get; set; }
        public int RecStatus { get; set; } = 1; 
    }
}