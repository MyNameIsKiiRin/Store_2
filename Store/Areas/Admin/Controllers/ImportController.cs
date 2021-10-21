using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models.EF;
using Store.Models.DAO;
namespace Store.Areas.Admin.Controllers
{
    public class ImportController : BaseController
    {
        DBStore db = new DBStore();
        // GET: Admin/Import
        public ActionResult Index()
        {
            var supDao = new SupplierDAO().sup();
            ViewBag.sup = supDao;
            var prodao = new ProductDAO().products();
            ViewBag.pro = prodao;
            return View();
        }
        [HttpPost]
        public ActionResult import(PhieuNhap p, IEnumerable<ChiTietPhieuNhap> lst)
        {
            var supDao = new SupplierDAO().sup();
            ViewBag.sup = supDao;
            var prodao = new ProductDAO().products();
            ViewBag.pro = prodao;
            
            var dao = new ReceiptDAO();
            p.MaPN = dao.lastid();
            var result=dao.insert(p);
            SanPham sp;
            if(result)
            {
                foreach(var item in lst)
                {
                    sp = db.SanPhams.SingleOrDefault(n => n.MaSP == item.MaSP);
                    sp.SoLuongTon += item.SoLuongNhap;
                    item.MaPN = p.MaPN;
                }
                db.ChiTietPhieuNhaps.AddRange(lst);
                db.SaveChanges();

            }
            SetAlert("Nhập Hàng Thành Công", "success");
            return RedirectToAction("Index");
        }
    }
}