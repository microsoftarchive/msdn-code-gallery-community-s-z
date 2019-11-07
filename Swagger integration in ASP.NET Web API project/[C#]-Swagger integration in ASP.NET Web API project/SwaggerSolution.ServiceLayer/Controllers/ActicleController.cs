using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CommunityTunisiaProject.Standards.Helpers;
using SwaggerSolution.ServiceLayer.Models;
using WebGrease.Css.Extensions;

namespace SwaggerSolution.ServiceLayer.Controllers
{
    /// <summary>
    /// The Controller of Article
    /// </summary>
    [RoutePrefix("article")]
    public class ActicleController : ApiController
    {
        private readonly IList<ArticleModel> _articles;

        /// <summary>
        /// ActicleController Constructor
        /// </summary>
        public ActicleController()
        {
            _articles = new List<ArticleModel>();
            var articleModel1 = new ArticleModel
            {
                Id = 1,
                ProductName = "Article1",
                ProductPrice = "123"
            };

            var articleModel2 = new ArticleModel
            {
                Id = 2,
                ProductName = "Article2",
                ProductPrice = "523"
            };
            _articles.Add(articleModel1);
            _articles.Add(articleModel2);

        }

        /// <summary>
        /// Get the list of articles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            var articleResultModel = new ArticleResultModel()
            {
                Data = new List<ArticleModel>(),
                Errors = new List<string>()
            };

            _articles.ForEach(a =>
            {
                articleResultModel.Data.Add(a);
            });

            var result = new Return<ArticleResultModel>().OK().WithResult(articleResultModel);

            var statusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), result.StatusDetail.ToString());
            return Request.CreateResponse(statusCode, result);
        }

        /// <summary>
        /// Get an article by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public ArticleModel Get(int id)
        {
            return _articles.FirstOrDefault(a => a.Id == id);
        }

        // POST: api/Acticle
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Acticle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Acticle/5
        public void Delete(int id)
        {
        }
    }
}
