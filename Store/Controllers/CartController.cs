using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models.DAO;
using Store.Models.EF;
namespace Store.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public List<CartItem> GetCart()
        {
            List<CartItem> LstCart = Session["Cart"] as List<CartItem>;
            if(LstCart==null)
            {
                LstCart = new List<CartItem>();
                Session["Cart"] = LstCart;
                return LstCart;
            }
            return LstCart;
        }
        public ActionResult AddToCart(string id,string cfid, string url)
        {
            //Kiểm tra sản phẩm
            var sp = new ProductDAO().GetById(id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng
            List<CartItem> LstCart = GetCart();
            //Nếu sản phẩm đã tồn tại
            CartItem CartCheck = LstCart.SingleOrDefault(n => n.masp == id && n.mach==cfid);
            if (CartCheck != null)
            {
                if (sp.SoLuongTon < CartCheck.soluong)
                {
                    return null;
                }
                CartCheck.soluong++;
                CartCheck.thanhtien = CartCheck.soluong * CartCheck.dongia;
                return Redirect(url);
            }
            
            CartItem itemcart = new CartItem(id,cfid);
            if (sp.SoLuongTon < itemcart.soluong) return null;
                LstCart.Add(itemcart);
            return Redirect(url);
        }
        public ActionResult UpdateCart(string id, string cfid)
        {
            if(Session["Cart"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            var sp = new ProductDAO().GetById(id);
            if(sp==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<CartItem> LstCart = GetCart();
            CartItem CartCheck = LstCart.SingleOrDefault(n => n.masp == id && n.mach == cfid);
            if (CartCheck == null) return RedirectToAction("Index", "Home");
            return View(CartCheck);
        }
        public double Total()
        {
            List<CartItem> LstCart = Session["Cart"] as List<CartItem>;
            if (LstCart == null)
            {
                return 0;
            }
            return LstCart.Sum(n => n.soluong);
        }
        public decimal TotalMoney()
        {
            List<CartItem> LstCart = Session["Cart"] as List<CartItem>;
            if (LstCart == null)
            {
                return 0;
            }
            return LstCart.Sum(n => n.thanhtien);
        }
        public ActionResult Index()
        {
            List<CartItem> cart = GetCart();
            return View(cart);
        }
    }
}