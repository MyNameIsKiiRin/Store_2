using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models.DAO;
using Store.Models.EF;
namespace Store.Areas.Admin.Controllers
{
    public class RevenueController : Controller
    {
        
        int month = 12;
        // GET: Admin/Revenue
        public ActionResult Index(int? year)
        {
            if (year == null) year = DateTime.Now.Year;
            var dao = new OrderDAO();
            List<RevenueDAO> Lstrevenue = new List<RevenueDAO>();
            for(int i=1;i<=month;i++)
            {
                var revenue = new RevenueDAO();
                revenue.Thang = i;
                revenue.DonHang = dao.count(i, year);
                revenue.TongSp = dao.product(i, year);
                revenue.DoanhThu = dao.total(i, year);
                Lstrevenue.Add(revenue);

            }
            return View(Lstrevenue);
        }
    }
}