using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Social_website.Models;

namespace ask.Api.Controllers
{
    public class usersController : ApiController
    {
        private AskContext db = new AskContext();

        // GET: api/users
        public IQueryable<users> GetUsers()
        {
            return db.Users;
        }

        // GET: api/users/5
        [ResponseType(typeof(users))]
        public IHttpActionResult Getusers(int id)
        {
            users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putusers(int id, users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.Id)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/users
        [ResponseType(typeof(users))]
        public IHttpActionResult Postusers(users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.Id }, users);
        }

        // DELETE: api/users/5
        [ResponseType(typeof(users))]
        public IHttpActionResult Deleteusers(int id)
        {
            users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool usersExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}