using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Social_website.Models;

namespace ask.Api.Controllers
{
    public class answersController : ApiController
    {
        private AskContext db = new AskContext();

        // GET: api/answers
        public IQueryable<answers> GetAnswers()
        {
            return db.Answers;
        }

        // GET: api/answers/5
        [ResponseType(typeof(answers))]
        public async Task<IHttpActionResult> Getanswers(int id)
        {
            answers answers = await db.Answers.FindAsync(id);
            if (answers == null)
            {
                return NotFound();
            }

            return Ok(answers);
        }

        // PUT: api/answers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putanswers(int id, answers answers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answers.Id)
            {
                return BadRequest();
            }

            db.Entry(answers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!answersExists(id))
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

        // POST: api/answers
        [ResponseType(typeof(answers))]
        public async Task<IHttpActionResult> Postanswers(answers answers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Answers.Add(answers);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (answersExists(answers.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = answers.Id }, answers);
        }

        // DELETE: api/answers/5
        [ResponseType(typeof(answers))]
        public async Task<IHttpActionResult> Deleteanswers(int id)
        {
            answers answers = await db.Answers.FindAsync(id);
            if (answers == null)
            {
                return NotFound();
            }

            db.Answers.Remove(answers);
            await db.SaveChangesAsync();

            return Ok(answers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool answersExists(int id)
        {
            return db.Answers.Count(e => e.Id == id) > 0;
        }
    }
}