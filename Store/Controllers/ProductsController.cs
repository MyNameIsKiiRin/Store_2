using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models.EF;
using Store.Models.DAO;
namespace Store.Controllers
{
    public class ProductsController : BaseController
    {
        static int ID ;
        // GET: Products
        public ActionResult Index(int id=0)
        {
            
            if(id==0)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var sp = new ProductDAO().product(id);
            if(sp==null)
            {
                return HttpNotFound();
            }
            ID = id;
            ViewBag.CountComment = new CommonDAO().CountCmt(id);
            var config = new ProductDAO().option(id);
            ViewBag.Config = config;
            ViewBag.Related = new ProductDAO().Related(id);
            ThanhVien mem = Session["Customer"] as ThanhVien;
            if (mem != null) 
                ViewBag.check = new CommonDAO().checkOrder(mem.MaThanhVien, id);
            return View(sp);
        }
        public ActionResult Config(int id)
        {
            var config = new ProductDAO().config(id);
            return PartialView(config);
        }
        public ActionResult comment(int id)
        {
            var comment = new CommonDAO().getComment(id);
            return PartialView(comment);
        }
        [HttpPost]
        public ActionResult PostComment(BinhLuan cmt)
        {
            var dao= new CommonDAO();
            ThanhVien mem = Session["Customer"] as ThanhVien;
            bool create=dao.Insert(cmt,ID,mem.MaThanhVien);
            if(create)
            {
                SetAlert("Cảm Ơn Phản Hồi Từ Bạn", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Đã có lỗi xảy ra", "success");
            return RedirectToAction("Index", new {@id=ID});
        }

    }
}