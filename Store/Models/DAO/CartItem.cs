using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Models.EF;
namespace Store.Models.DAO
{
    [Serializable]
    public class CartItem
    {
        public string masp { get; set; }
        public string tensp { get; set; }
        public int soluong { get; set; }
        public string hinhanh { get; set; }
        public decimal dongia { get; set; }
        public decimal thanhtien { get; set; }
        public string cauhinh { get; set; }
        public string mach { get; set; }


        public CartItem(string id,string cfid)
        {
            DBStore db = new DBStore();
            masp = id;
            mach = cfid;
            soluong = 1;
            SanPham sp = db.SanPhams.Single(n => n.MaSP == id);
            CauHinh cf = db.CauHinhs.Single(n => n.MaCH == cfid);
            tensp = sp.TenSP;
            hinhanh = sp.HinhAnh1;
            dongia = sp.DonGia.Value;
            cauhinh = cf.TenCH;
            thanhtien = soluong * dongia;
        }
        public CartItem() { }
    }
}