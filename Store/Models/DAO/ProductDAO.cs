using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Models.EF;
namespace Store.Models.DAO
{
    public class ProductDAO
    {
        DBStore db = null;

        public ProductDAO()
        {
            db = new DBStore();
        }
        public SanPham GetById(string id)
        {
            return db.SanPhams.SingleOrDefault(n => n.MaSP == id);
        }
        public IEnumerable<SanPham> products()
        {
            return db.SanPhams.Where(n=>n.TrangThai==true);
        }
        public IEnumerable<CauHinh> option(string id)
        {
            return db.CauHinhs.Where(n => n.MaSP==id);
        }
        public CauHinh config(string id)
        {
            return db.CauHinhs.FirstOrDefault(n=>n.MaSP==id);
        }
        public SanPham product(string id)
        {
            return db.SanPhams.SingleOrDefault(n => n.MaSP == id&&n.TrangThai==true);
        }
        public IEnumerable<SanPham> Tablet()
        {
            return db.SanPhams.Where(n=>n.MaLoaiSP=="7" && n.TrangThai==true);
        }
        public IEnumerable<SanPham> Apple()
        {
            return db.SanPhams.Where(n => n.MaNSX == "1" && n.TrangThai == true);
        }
        public IEnumerable<SanPham> Sound()
        {
            return db.SanPhams.Where(n => n.MaLoaiSP == "10" && n.TrangThai == true);
        }
        public IEnumerable<SanPham> New_Products()
        {
            return db.SanPhams.Where(n => n.Moi == true && n.TrangThai == true);
        }
        public List<SanPham> Related(string id)
        {
            var pro = db.SanPhams.Find(id);
            return db.SanPhams.Where(n => n.MaSP != id && n.MaLoaiSP == pro.MaLoaiSP).ToList();
        }
    }
}