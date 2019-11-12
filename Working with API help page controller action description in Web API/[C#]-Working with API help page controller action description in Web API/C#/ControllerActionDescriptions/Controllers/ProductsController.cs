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
using ControllerActionDescriptions.Models;

namespace ControllerActionDescriptions.Controllers
{
    public class ProductsController : ApiController
    {
        private TrialsDBEntities db = new TrialsDBEntities();
        #region GetProducts
        /// <summary>
        /// Get all the products available
        /// GET: api/Products
        /// </summary> 
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }
        #endregion

        #region GetProductWithParameter
        /// <summary>
        /// Get a single product by id
        /// GET: api/Products/5
        /// <param name="id"></param>
        /// </summary> 
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        #endregion
    }
}