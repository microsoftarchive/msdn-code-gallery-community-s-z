using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CSdotnetWebTestyViewModel;
using CSdotnetWebTesty.BLL;
using System.Web.Http.Routing;
using System.Data.Entity.Infrastructure;


namespace CSdotnetWebTesty.WebAPI.Controllers
{
    public class DoctorsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<doctorVM> Get(int page = 0, int pageSize = 10)
        {
            BLL.doctorBLL grouppermissions = new BLL.doctorBLL();
            IQueryable<doctorVM> query;
            query = grouppermissions.Get().AsQueryable<doctorVM>();

            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var urlHelper = new UrlHelper(Request);
            var prevLink = page > 0 ? urlHelper.Link("doctors", new { page = page - 1, pageSize = pageSize }) : "";
            var nextLink = page < totalPages - 1 ? urlHelper.Link("doctors", new { page = page + 1, pageSize = pageSize }) : "";

            var paginationHeader = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                PrevPageLink = prevLink,
                NextPageLink = nextLink
            };

            System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination",
                                                                Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));

            var results = query
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .AsQueryable<doctorVM>();


            return results;
        }

        // GET api/<controller>/5
        public doctorVM Get(int id)
        {
            doctorBLL DoctorBLL = new doctorBLL();
            return DoctorBLL.GetbyId(id);
        }

        // POST api/<controller>
        public HttpResponseMessage PostDoctorInfo(doctorVM doctorinfo)
        {
            if (ModelState.IsValid)
            {
                BLL.doctorBLL grouppermissions = new BLL.doctorBLL();
                grouppermissions.Create(doctorinfo);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, doctorinfo);
                response.Headers.Location = new Uri(Url.Link("DoctorsApi", new { id = doctorinfo.id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage PutDoctorInfo(int id, doctorVM doc)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(doctorinfo).State = EntityState.Modified;

                try
                {
                    BLL.doctorBLL grouppermissions = new BLL.doctorBLL();
                    grouppermissions.Update(doc);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {

            doctorBLL DoctorBLL = new doctorBLL();
            //return DoctorBLL.GetbyId(id);
            doctorVM doctorinfo = DoctorBLL.GetbyId(id);


            // db.EmployeeInfoes.Remove(doctorinfo);


            if (doctorinfo == null)
            {

                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                DoctorBLL.Delete(id);
                //  db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, doctorinfo);
        }
    }
}