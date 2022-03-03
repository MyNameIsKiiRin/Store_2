using System;
using Store.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models.DAO;
using Store.Models.EF;
using System.Configuration;
namespace Store.Controllers
{
    public class CartController : BaseController
    {
        DBStore db = new DBStore();
        // GET: Cart
        public List<CartItem> GetCart()
        {
            List<CartItem> LstCart = Session["Cart"] as List<CartItem>;
            
            if (LstCart==null)
            {
                LstCart = new List<CartItem>();
                Session["Cart"] = LstCart;
                return LstCart;
            }
            return LstCart;
        }
        public ActionResult AddToCart(int id,int cfid, string url)
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
                    SetAlert("Số Lượng Sản Phẩm Không Đủ", "warning");
                }
                CartCheck.soluong++;
                CartCheck.thanhtien = CartCheck.soluong * CartCheck.dongia;
                SetAlert("Thêm vào giỏ hàng thành công", "seccess");
                return Redirect(url);
            }
            
            CartItem itemcart = new CartItem(id,cfid);
            if (sp.SoLuongTon < itemcart.soluong) SetAlert("Số Lượng Sản Phẩm Không Đủ", "warning"); ;
                LstCart.Add(itemcart);
            SetAlert("Thêm vào giỏ hàng thành công", "seccess");
            return Redirect(url);
        }
        [HttpGet]
        public ActionResult UpdateCart(int id, int cfid)
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
            ViewBag.Cart = LstCart;
            return View(CartCheck);
        }
        [HttpPost]
        public ActionResult UpdateCart(CartItem cartItem)
        {
            var sp = new ProductDAO().GetById(cartItem.masp);
            if (sp.SoLuongTon < cartItem.soluong)
            {
                return null;
            }
            List<CartItem> LstCart = GetCart();
            CartItem ItemUpdate = LstCart.Find(n => n.masp == cartItem.masp && n.mach == cartItem.mach);
            ItemUpdate.soluong = cartItem.soluong;
            if (ItemUpdate.soluong == 0) DeleteCart(ItemUpdate.masp, ItemUpdate.mach);
            ItemUpdate.thanhtien = ItemUpdate.soluong * ItemUpdate.dongia;
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCart(int id,int cfid)
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var sp = new ProductDAO().GetById(id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<CartItem> LstCart = GetCart();
            CartItem CartCheck = LstCart.SingleOrDefault(n => n.masp == id && n.mach == cfid);
            if (CartCheck == null) return RedirectToAction("Index", "Home");
            LstCart.Remove(CartCheck);
            return RedirectToAction("Index");
        }
        public ActionResult Order(DonDatHang order,KhachHang customer)
        {
            if (Session["Cart"] == null)
                return RedirectToAction("Index", "Home");
            KhachHang Customer = new KhachHang();
            if(Session["Customer"]==null)
            {
                Customer = customer;
                
                db.KhachHangs.Add(Customer);
                db.SaveChanges();
            }
            else
            {
                ThanhVien mem = Session["Customer"] as ThanhVien;
                Customer.TenKH = mem.HoTen;
                Customer.DiaChi = mem.DiaChi;
                Customer.Email = mem.Email;
                Customer.SoDienThoai = mem.SoDienThoai;
                Customer.MaThanhVien= mem.MaThanhVien;
                db.KhachHangs.Add(Customer);
                db.SaveChanges();
            }
            order.MaKH = Customer.MaKH;
            var dao = new OrderDAO().Order(order);
            List<CartItem> LstCart = GetCart();
            if(dao)
            {
                foreach (var item in LstCart)
                {
                    
                    ChiTietDonDatHang dtorder = new ChiTietDonDatHang();
                    
                    
                    dtorder.MaDDH = order.MaDDH;
                    dtorder.MaSP = item.masp;
                    dtorder.TenSP = item.tensp;
                    dtorder.SoLuong = item.soluong;
                    dtorder.DonGia = item.dongia;
                    db.ChiTietDonDatHangs.Add(dtorder);
                    db.SaveChanges();
                } 
            }
            Payment();
            Session["Cart"] = null;
            return RedirectToAction("Index");
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
        public ActionResult Payment()
        {
            string url = ConfigurationManager.AppSettings["Url"];
            string returnUrl = ConfigurationManager.AppSettings["ReturnUrl"];
            string tmnCode = ConfigurationManager.AppSettings["TmnCode"];
            string hashSecret = ConfigurationManager.AppSettings["HashSecret"];

            PayLib pay = new PayLib();

            pay.AddRequestData("vnp_Version", "2.0.0"); //Phiên bản api mà merchant kết nối. Phiên bản hiện tại là 2.0.0
            pay.AddRequestData("vnp_Command", "pay"); //Mã API sử dụng, mã cho giao dịch thanh toán là 'pay'
            pay.AddRequestData("vnp_TmnCode", tmnCode); //Mã website của merchant trên hệ thống của VNPAY (khi đăng ký tài khoản sẽ có trong mail VNPAY gửi về)
            pay.AddRequestData("vnp_Amount",(TotalMoney()*100).ToString()); //số tiền cần thanh toán, công thức: số tiền * 100 - ví dụ 10.000 (mười nghìn đồng) --> 1000000
            pay.AddRequestData("vnp_BankCode", ""); //Mã Ngân hàng thanh toán (tham khảo: https://sandbox.vnpayment.vn/apis/danh-sach-ngan-hang/), có thể để trống, người dùng có thể chọn trên cổng thanh toán VNPAY
            pay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss")); //ngày thanh toán theo định dạng yyyyMMddHHmmss
            pay.AddRequestData("vnp_CurrCode", "VND"); //Đơn vị tiền tệ sử dụng thanh toán. Hiện tại chỉ hỗ trợ VND
            pay.AddRequestData("vnp_IpAddr", Util.GetIpAddress()); //Địa chỉ IP của khách hàng thực hiện giao dịch
            pay.AddRequestData("vnp_Locale", "vn"); //Ngôn ngữ giao diện hiển thị - Tiếng Việt (vn), Tiếng Anh (en)
            pay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang"); //Thông tin mô tả nội dung thanh toán
            pay.AddRequestData("vnp_OrderType", "other"); //topup: Nạp tiền điện thoại - billpayment: Thanh toán hóa đơn - fashion: Thời trang - other: Thanh toán trực tuyến
            pay.AddRequestData("vnp_ReturnUrl", returnUrl); //URL thông báo kết quả giao dịch khi Khách hàng kết thúc thanh toán
            pay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString()); //mã hóa đơn

            string paymentUrl = pay.CreateRequestUrl(url, hashSecret);

            return Redirect(paymentUrl);
        }

        public ActionResult PaymentConfirm()
        {
            if (Request.QueryString.Count > 0)
            {
                string hashSecret = ConfigurationManager.AppSettings["HashSecret"]; //Chuỗi bí mật
                var vnpayData = Request.QueryString;
                PayLib pay = new PayLib();

                //lấy toàn bộ dữ liệu được trả về
                foreach (string s in vnpayData)
                {
                    if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                    {
                        pay.AddResponseData(s, vnpayData[s]);
                    }
                }

                long orderId = Convert.ToInt64(pay.GetResponseData("vnp_TxnRef")); //mã hóa đơn
                long vnpayTranId = Convert.ToInt64(pay.GetResponseData("vnp_TransactionNo")); //mã giao dịch tại hệ thống VNPAY
                string vnp_ResponseCode = pay.GetResponseData("vnp_ResponseCode"); //response code: 00 - thành công, khác 00 - xem thêm https://sandbox.vnpayment.vn/apis/docs/bang-ma-loi/
                string vnp_SecureHash = Request.QueryString["vnp_SecureHash"]; //hash của dữ liệu trả về

                bool checkSignature = pay.ValidateSignature(vnp_SecureHash, hashSecret); //check chữ ký đúng hay không?

                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00")
                    {
                        //Thanh toán thành công
                        ViewBag.Message = "Thanh toán thành công hóa đơn " + orderId + " | Mã giao dịch: " + vnpayTranId;
                    }
                    else
                    {
                        //Thanh toán không thành công. Mã lỗi: vnp_ResponseCode
                        ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý hóa đơn " + orderId + " | Mã giao dịch: " + vnpayTranId + " | Mã lỗi: " + vnp_ResponseCode;
                    }
                }
                else
                {
                    ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý";
                }
            }

            return View();
        }
        
    }
}