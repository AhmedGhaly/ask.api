using Antlr.Runtime;
using Social_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;


namespace ask.Api.Controllers
{
    public class operationController: ApiController
    {
        private AskContext db = new AskContext();




        [HttpPost]
        public IHttpActionResult signup(users user)
        {
            if (checkEmail(user.Email))
            {

                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Ok("done..");

                }
                return Unauthorized();
            }
            return Unauthorized();

        }
        [HttpPut]
        public IHttpActionResult Login(users user)
        {
            if (user.Email != null && user.Password != null)
            {
                users myuser = db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                if (myuser != null)
                {

                    string key = "my_secret_key_12345"; //Secret key which will be used later during validation    
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                    var data = new List<Claim>();
                    data.Add(new Claim("id", myuser.Id.ToString()));
                    var token = new JwtSecurityToken(
                                claims: data,
                                expires: DateTime.Now.AddDays(1),
                                signingCredentials: credentials);
                    var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(jwt_token);

                }
                return Unauthorized();
            }
            return BadRequest();
        }





        private bool checkEmail(string Email)
        {

            users user = db.Users.Where(n => n.Email == Email).FirstOrDefault();
            if (user == null)
                return true;
            return false;

        }




    }
}