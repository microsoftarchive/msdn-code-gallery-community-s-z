#region File Attributes

// VirtueBuild.System  Project: AdminWeb
// File:  ValuesController.cs
// Created By: Slava 
// Created On: 2013.05.11 

#endregion

namespace AdminWeb.Controllers {
    #region

    using System.Collections.Generic;
    using System.Web.Http;

    using BaseSystem;

    #endregion

    public class ValuesController : BaseApiController
    {

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value) {}

        // PUT api/values/5
        public void Put(int id, [FromBody] string value) {}

        // DELETE api/values/5
        public void Delete(int id) {}

    }
}