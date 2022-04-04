using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models.DAO;
using Store.Models.EF;
using System.Net.Mail;
using Store.Common;

namespace Store.Areas.Admin.Controllers
{
    public class PaymentController : BaseController
    {
        
        // GET: Admin/Payment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Unpaid()
        {
            var dao = new OrderDAO().GetOrder();
            return View(dao);
        }
        [HttpPost]
        public ActionResult accept(ChiTietDonDatHang ct)
        {
            
            var result = new OrderDAO().getAccept(ct.MaDDH.GetValueOrDefault());
            var order=new OrderDAO().Details(ct.MaDDH.GetValueOrDefault());
            if(result==true)
            {
                int id = order.MaDDH;
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Common/Templates/mail.html"));
                content=content.Replace("{{MaDDH}}", ct.MaDDH.ToString());
                content = content.Replace("{{TenKH}}", order.KhachHang.TenKH.ToString());
                content = content.Replace("{{DiaChi}}", order.KhachHang.DiaChi.ToString());
                content = content.Replace("{{SoDienThoai}}", order.KhachHang.SoDienThoai.ToString());
                
                new SendMail().sendMail(order.KhachHang.Email,"Đặt Hàng Thành Công",content);
                SetAlert("Duyệt đơn hàng thành công", "seccess");
                return RedirectToAction("Index");
            }
            SetAlert("Duyệt đơn hàng thất bại", "success");
            return RedirectToAction("Index");
        }
        [HttpPost]

        public ActionResult cancel(int id)
        {
            var result=new OrderDAO().cancel(id);
            if(result)
            {
                var order = new OrderDAO().Details(id);
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Common/Templates/cancelMail.html"));
                content = content.Replace("{{MaDDH}}", order.MaDDH.ToString());
                content = content.Replace("{{TenKH}}", order.KhachHang.TenKH.ToString());
                new SendMail().sendMail(order.KhachHang.Email, "Đơn hàng đã bị hủy", content);
                SetAlert("Đã hủy đơn hàng thành công", "success");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index","Payment");
        }
        public ActionResult Paid()
        {
            var dao = new OrderDAO().Paid();
            return View(dao);
        }
        [HttpPost]
        public ActionResult delivery(int id)
        {
            var result = new OrderDAO().delivery(id);
            if(result)
            {
                var order = new OrderDAO().Details(id);
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Common/Templates/successMail.html"));
                content = content.Replace("{{MaDDH}}", order.MaDDH.ToString());
                content = content.Replace("{{TenKH}}", order.KhachHang.TenKH.ToString());
                new SendMail().sendMail(order.KhachHang.Email, "Đơn hàng đã được giao thành công", content);
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult success()
        {
            var result = new OrderDAO().Delivery();
            return View(result);
        }
        public ActionResult orderDetail(int id)
        {
            ViewBag.order = new OrderDAO().Details(id);
            var dao = new OrderDAO().orderDetail(id);
            return View(dao);
        }
        public void sendEmail(string tittle,string toEmail,string fromEmail,string pwd,string content)
        {
            MailMessage mail=new MailMessage();
            mail.To.Add(toEmail);
            mail.From = new MailAddress(fromEmail);
            mail.Subject = tittle;
            mail.Body = content;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials=false;
            smtp.Credentials = new System.Net.NetworkCredential(fromEmail, pwd);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}