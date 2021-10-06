using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models.EF;
using Store.Models.DAO;
namespace Store.Controllers
{
    public class ProductsController : Controller
    {
        string ID = "";
        // GET: Products
        public ActionResult Index(string id)
        {
            ID = id;
            if(id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var sp = new ProductDAO().product(id);
            if(sp==null)
            {
                return HttpNotFound();
            }
            var config = new ProductDAO().option(id);
            ViewBag.Config = config;
            ViewBag.Related = new ProductDAO().Related(id);
            return View(sp);
        }
        public ActionResult Config(string id)
        {
            var config = new ProductDAO().config(id);
            return PartialView(config);
        }

    }
}