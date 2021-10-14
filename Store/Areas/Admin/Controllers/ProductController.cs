using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models.DAO;
using Store.Models.EF;
namespace Store.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            var dao = new ProductDAO().products();
            return View(dao);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var supDao = new SupplierDAO().sup();
            ViewBag.sup = supDao;
            var prodao = new ProducerDAO().procer();
            ViewBag.producer = prodao;
            var typedao = new ProductTypeDAO().type();
            ViewBag.type = typedao;
            
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(SanPham pro, HttpPostedFileBase[] file)
        {
            
                if (file!=null)
                {
                    string pic1 = System.IO.Path.GetFileName(file[0].FileName);
                    string path = System.IO.Path.Combine(
                                            Server.MapPath("~/assets/Client/Product_Images/"), pic1);
                    string pic2 = System.IO.Path.GetFileName(file[1].FileName);
                    path = System.IO.Path.Combine(
                                                Server.MapPath("~/assets/Client/Product_Images/"), pic2);
                    string pic3 = System.IO.Path.GetFileName(file[1].FileName);
                    path = System.IO.Path.Combine(
                                                Server.MapPath("~/assets/Client/Product_Images/"), pic3);
                if (System.IO.File.Exists(path))
                    {
                        ViewBag.upload = "Hình Ảnh Đã Tồn Tại";
                    }
                    else
                    {
                        file[0].SaveAs(path);
                        pro.HinhAnh1 = pic1;
                        file[1].SaveAs(path);
                        pro.HinhAnh2 = pic2;
                        file[2].SaveAs(path);
                        pro.HinhAnh3 = pic3;
                    }
                    // file is uploaded
                
                }
            
            var dao = new ProductDAO();
            pro.MaSP = dao.lastid();
            var result=dao.Insert(pro);
            if(result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dao = new ProductDAO().GetById(id);
            return View(dao);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SanPham pro, HttpPostedFileBase[] file)
        {
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i] != null)
                {
                    string pic1 = System.IO.Path.GetFileName(file[0].FileName);
                    string path = System.IO.Path.Combine(
                                            Server.MapPath("~/assets/Client/Product_Images/"), pic1);
                    string pic2 = System.IO.Path.GetFileName(file[1].FileName);
                    path = System.IO.Path.Combine(
                                                Server.MapPath("~/assets/Client/Product_Images/"), pic2);
                    string pic3 = System.IO.Path.GetFileName(file[1].FileName);
                    path = System.IO.Path.Combine(
                                                Server.MapPath("~/assets/Client/Product_Images/"), pic3);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.upload = "Hình Ảnh Đã Tồn Tại";
                    }
                    else
                    {
                        file[0].SaveAs(path);
                        pro.HinhAnh1 = pic1;
                        file[1].SaveAs(path);
                        pro.HinhAnh2 = pic2;
                        file[2].SaveAs(path);
                        pro.HinhAnh3 = pic3;
                    }
                    // file is uploaded

                }
            }
            var dao = new ProductDAO().update(pro);
            if(dao)
            {
                return RedirectToAction("Index");
            }
            ViewBag.er = "Cập Nhật Thất Bại";
            return View(); 
        }
    }
}