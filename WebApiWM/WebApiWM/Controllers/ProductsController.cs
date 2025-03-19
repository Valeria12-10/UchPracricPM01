using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using System.Web.Http;
using System.Web.Mvc;
using WebApiWM.Models;
using WebApiWM.Entities;

namespace WebApiWM.Controllers
{
    public class ProductsController : ApiController
    {
        private СкладыEntities db = new СкладыEntities();

        // GET: api/товары
        [ResponseType(typeof(List<Products>))]

        public IHttpActionResult GetGoods()
        {
            return Ok(db.Товары.ToList().ConvertAll(p => new Products(p)));
        }

        [ResponseType(typeof(List<Products>))]
        public IHttpActionResult PostGoods([FromBody] Товары товар)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Товары.Add(товар);
            db.SaveChanges();
            var response = new Products(товар);
            return CreatedAtRoute("DefaultApi", new { id = товар.IDТовара }, response);
        }
    }
}