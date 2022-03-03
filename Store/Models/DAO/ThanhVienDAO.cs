using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Store.Models.EF;

namespace Store.Models.DAO
{
    public class ThanhVienDAO
    {
        private DBStore db = null;
        public ThanhVienDAO()
        {
            db = new DBStore();
        }

        public ThanhVien login(ThanhVien tv)
        {
            var bytes = Encoding.UTF8.GetBytes(tv.MatKhau);//123=>202cb962ac59075b964b07152d234b70
            var hash = MD5.Create().ComputeHash(bytes);
            Convert.ToBase64String(hash);
            return db.ThanhViens.SingleOrDefault(x => x.TaiKhoan == tv.TaiKhoan && x.MatKhau == tv.MatKhau);
        }

        public bool register(ThanhVien tv)
        {
            if (db.ThanhViens.Where(x => x.TaiKhoan == tv.TaiKhoan).Count() <= 0)
            {
                var bytes = Encoding.UTF8.GetBytes(tv.MatKhau);
                var hash = MD5.Create().ComputeHash(bytes);
                tv.MatKhau = Convert.ToBase64String(hash);
                db.Configuration.ValidateOnSaveEnabled = false;
                var id = db.ThanhViens.Count();
                
                db.ThanhViens.Add(tv);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}