using CompositeKeySupport.Models;
using Microsoft.Data.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;

namespace CompositeKeySupport.Controllers
{
    public class PeopleController : ODataController
    {
        private PeopleRepository _repo = new PeopleRepository();

        public IEnumerable<Person> Get()
        {
            return _repo.Get();
        }

        public Person Get([FromODataUri] string firstName, [FromODataUri] string lastName)
        {
            Person person = _repo.Get(firstName, lastName);
            if (person == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return person;
        }

        public HttpResponseMessage PutPerson([FromODataUri] string firstName, [FromODataUri] string lastName, Person person)
        {
            if (ModelState.IsValid && firstName == person.FirstName && lastName == person.LastName)
            {
                _repo.UpdateOrAdd(person);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [AcceptVerbs("PATCH", "MERGE")]
        public HttpResponseMessage PatchPerson([FromODataUri] string firstName, [FromODataUri] string lastName, Delta<Person> delta)
        {
            if (ModelState.IsValid)
            {
                var person = _repo.Get(firstName, lastName);
                if (person == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                delta.Patch(person);
                _repo.UpdateOrAdd(person);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage PostPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateOrAdd(person);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, person);
                string key = string.Format(
                    "{0}={1},{2}={3}",
                    "FirstName", ODataUriUtils.ConvertToUriLiteral(person.FirstName, Microsoft.Data.OData.ODataVersion.V3),
                    "LastName", ODataUriUtils.ConvertToUriLiteral(person.LastName, Microsoft.Data.OData.ODataVersion.V3));
                response.Headers.Location = new Uri(Url.ODataLink(
                    new EntitySetPathSegment("People"),
                    new KeyValuePathSegment(key)));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage DeletePerson([FromODataUri] string firstName, [FromODataUri] string lastName)
        {
            var person = _repo.Remove(firstName, lastName);
            if (person == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, person);
        }
    }
}
