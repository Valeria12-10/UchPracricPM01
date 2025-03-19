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
    public class WarehouseController : ApiController
    {
        private СкладыEntities db = new СкладыEntities();

        // GET: Warehouse
        [ResponseType(typeof(List<Warehouse>))]

        public IHttpActionResult GetWarehouse()
        {
            return Ok(db.Склады.ToList().ConvertAll(p => new Warehouse(p)));
        }
    }
}