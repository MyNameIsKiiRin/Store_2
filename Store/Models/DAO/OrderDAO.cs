using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Models.EF;
namespace Store.Models.DAO
{
    public class OrderDAO
    {
        DBStore db = null;
        public OrderDAO()
        {
            db = new DBStore();
        }

        public bool Order(DonDatHang order)
        {
            order.MaDDH = "DDH" +(string) DateTime.Now.ToString("hh:mm:ss");
            order.NgayDat = DateTime.Now;
            order.TinhTrangGiaoHang = false;
            order.DaThanhToan = false;
            order.UuDai = 0;
            order.HuyDon = false;
            order.TrangThai = true;
            db.DonDatHangs.Add(order);
            db.SaveChanges();
            return true;
        }
    }
}