using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models.DAO;
using Store.Models.EF;
using PagedList;
namespace Store.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(int page=1,int pageSize=10)
        {
            var dao = new ProductDAO().page_list_product(page,pageSize);
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
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i]!= null)
                {
                    string pic = System.IO.Path.GetFileName(file[i].FileName);
                    string pic1 = System.IO.Path.GetFileName(file[0].FileName);
                    string path = System.IO.Path.Combine(
                                            Server.MapPath("~/assets/Client/Product_Images/"), pic);
                    string pic2 = System.IO.Path.GetFileName(file[1].FileName);

                    string pic3 = System.IO.Path.GetFileName(file[2].FileName);
                    if (System.IO.File.Exists(path))
                    {
                        SetAlert("Hình Ảnh Đã Tồn Tại","warning");
                    }
                    else
                    {
                        file[i].SaveAs(path);
                        pro.HinhAnh1 = pic1;

                        pro.HinhAnh2 = pic2;

                        pro.HinhAnh3 = pic3;
                    }
                    // file is uploaded

                }
            }
            
            var dao = new ProductDAO();
            pro.MaSP = dao.lastid();
            var result=dao.Insert(pro);
            if(result)
            {
                SetAlert("Thêm Sản Phẩm Thành Công", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Thêm Sản Phẩm Thất Bại", "warning");
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
                    string pic = System.IO.Path.GetFileName(file[i].FileName);
                    string pic1 = System.IO.Path.GetFileName(file[0].FileName);
                    string path = System.IO.Path.Combine(
                                            Server.MapPath("~/assets/Client/Product_Images/"), pic);
                    string pic2 = System.IO.Path.GetFileName(file[1].FileName);

                    string pic3 = System.IO.Path.GetFileName(file[2].FileName);
                    if (System.IO.File.Exists(path))
                    {
                        SetAlert("Hình Ảnh Đã Tồn Tại", "warning");
                    }
                    else
                    {
                        file[i].SaveAs(path);
                        pro.HinhAnh1 = pic1;

                        pro.HinhAnh2 = pic2;

                        pro.HinhAnh3 = pic3;
                    }
                    // file is uploaded

                }
            }
            var dao = new ProductDAO().update(pro);
            if(dao)
            {
                SetAlert("Sửa Sản Phẩm Thành Công", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Sửa Sản Phẩm Thất Bại", "warning");
            return View(); 
        }
    }
}