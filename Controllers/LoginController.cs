using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentAppln4.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


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





            var email = login.Email;
            var password = login.Password;

            // Secret key for signing the token
            string secretKey = "your_secret_key_here";

            // Create claims for the token (e.g., email, user ID, roles, etc.)
            var claims = new[]
            {
    new Claim(JwtRegisteredClaimNames.Email, email),
    // Add more claims as needed
};

            // Create a token descriptor with the specified claims and expiration time
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(100), // Set token expiration time
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            // Create a token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // Generate the token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Serialize the token to a string
            var tokenString = tokenHandler.WriteToken(token);

            login.Token = tokenString;






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