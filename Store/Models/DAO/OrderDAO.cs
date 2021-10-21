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
        public DonDatHang Details(string id)
        {
            return db.DonDatHangs.SingleOrDefault(n => n.MaDDH == id);
        }
        public int count(int month, int? year)
        {
            
            return db.DonDatHangs.Count(n=>n.NgayDat.Value.Month==month && n.NgayDat.Value.Year==year);
        }
        public decimal total(int month, int? year)
        {
            decimal ToTal = 0;
            var order = db.DonDatHangs.Where(n => n.NgayDat.Value.Month == month && n.NgayDat.Value.Year == year);
            foreach(var item in order)
            {
                ToTal += decimal.Parse(item.ChiTietDonDatHangs.Sum(n => n.SoLuong * n.DonGia).Value.ToString());
            }
            return ToTal;
        }
        public int product(int month, int? year)
        {
            int ToTal = 0;
            var order = db.DonDatHangs.Where(n => n.NgayDat.Value.Month == month && n.NgayDat.Value.Year == year);
            foreach (var item in order)
            {
                ToTal +=int.Parse( item.ChiTietDonDatHangs.Sum(n => n.SoLuong).Value.ToString());
            }
            return ToTal;
        }
        public bool accept(string id)
        {
            var order = db.DonDatHangs.Find(id);
            var detail_order = db.ChiTietDonDatHangs.Where(n => n.MaDDH == id);
            foreach(var item in  detail_order)
            {
                SanPham sp = db.SanPhams.Find(item.MaSP);
                sp.SoLuongTon -= item.SoLuong;
            }
            order.DaThanhToan = true;
            db.SaveChanges();
            return true;
            
        }
        public bool delivery(string id)
        {
            var order = db.DonDatHangs.Find(id);
            order.TinhTrangGiaoHang = true;
            order.NgayGiao = DateTime.Now;
            db.SaveChanges();
            return true;

        }
        public string lastid()
        {
            int a = 0;
            List<int> lstid = new List<int>();
            IEnumerable<string> id = from temp in db.DonDatHangs select temp.MaDDH;
            foreach (var temp in id)
            {
                a = int.Parse(temp);
                lstid.Add(int.Parse(temp));
            }
            lstid.Sort();
            int max = lstid.Last();
            max++;
            return max.ToString();
        }
        public bool Order(DonDatHang order)
        {
            order.MaDDH = lastid();
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
        public IEnumerable<DonDatHang> GetOrder()
        {
            return db.DonDatHangs.Where(n=>n.TrangThai==true && n.TinhTrangGiaoHang==false && n.DaThanhToan==false &&n.HuyDon==false);
        }
        public IEnumerable<DonDatHang> Paid()
        {
            return db.DonDatHangs.Where(n => n.TrangThai == true && n.DaThanhToan == true && n.HuyDon == false && n.TinhTrangGiaoHang == false);
        }

        public IEnumerable<DonDatHang> Delivery()
        {
            return db.DonDatHangs.Where(n => n.TrangThai == true && n.DaThanhToan == true && n.HuyDon == false && n.TinhTrangGiaoHang == true);
        }
    }
}