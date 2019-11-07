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
using WebAPIWithHttpClient.Models;

namespace WebAPIWithHttpClient.Controllers
{
    public class tblTagsController : ApiController
    {
        private TrialsDBEntities db = new TrialsDBEntities();

        // GET: api/tblTags
        public IQueryable<tblTag> GettblTags()
        {
            return db.tblTags;
        }

        // GET: api/tblTags/5
        [ResponseType(typeof(tblTag))]
        public async Task<IHttpActionResult> GettblTag(int id)
        {
            tblTag tblTag = await db.tblTags.FindAsync(id);
            if (tblTag == null)
            {
                return NotFound();
            }

            return Ok(tblTag);
        }

        // PUT: api/tblTags/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuttblTag(int id, tblTag tblTag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblTag.tagId)
            {
                return BadRequest();
            }

            db.Entry(tblTag).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblTagExists(id))
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

        // POST: api/tblTags
        [ResponseType(typeof(tblTag))]
        public async Task<IHttpActionResult> PosttblTag(tblTag tblTag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblTags.Add(tblTag);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tblTag.tagId }, tblTag);
        }

        // DELETE: api/tblTags/5
        [ResponseType(typeof(tblTag))]
        public async Task<IHttpActionResult> DeletetblTag(int id)
        {
            tblTag tblTag = await db.tblTags.FindAsync(id);
            if (tblTag == null)
            {
                return NotFound();
            }

            db.tblTags.Remove(tblTag);
            await db.SaveChangesAsync();

            return Ok(tblTag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblTagExists(int id)
        {
            return db.tblTags.Count(e => e.tagId == id) > 0;
        }
    }
}