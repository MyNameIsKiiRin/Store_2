using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Models.EF;
namespace Store.Models.DAO
{
    public class CommonDAO
    {
        DBStore db = null;
        public CommonDAO()
        {
            db = new DBStore();
        }
        public QuangCao ads()
        {
            return db.QuangCaos.SingleOrDefault(n => n.TrangThai == true);
        }
        public IEnumerable<Footer> footer()
        {
            return db.Footers.Where(n => n.TrangThai == true);
        }
        public IEnumerable<BinhLuan> getComment(int id)
        {
            return db.BinhLuans.Where(n => n.MaSP == id).OrderBy(n=>n.NgayTao);
        }
        public bool checkOrder(int id,int productID)
        {
            var Customer=db.KhachHangs.Where(n=>n.MaThanhVien == id);
            if (Customer != null)
            {
                foreach (var item in Customer)
                {
                    var OrderID = db.DonDatHangs.SingleOrDefault(n => n.MaKH == item.MaKH);
                    var DetailOrderID = db.ChiTietDonDatHangs.Where(n => n.MaDDH == OrderID.MaDDH);
                    foreach (var item_2 in DetailOrderID)
                    {
                        if (item_2.MaSP == productID)
                            return true;
                    }
                }
            }
            return false;
        }
        public int CountCmt(int id)
        {
            return db.BinhLuans.Where(n => n.MaSP == id).Count();
        }
        public bool Insert(BinhLuan cmt,int idProduct,int idMem)
        {
            cmt.MaThanhVien = idMem;
            cmt.MaSP = idProduct;
            cmt.NgayTao = DateTime.Now;
            db.BinhLuans.Add(cmt);
            db.SaveChanges();
            return true;
        }

    }

}