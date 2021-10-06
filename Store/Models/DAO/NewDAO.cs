using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Models.EF;
namespace Store.Models.DAO
{
    public class NewDAO
    {
        DBStore db = null;

        public NewDAO()
        {
            db = new DBStore();
        }
        
        public TinTuc promotion()
        {
            return db.TinTucs.SingleOrDefault(n => n.TinKhuyenMai == true &&n.TrangThai==true);
        }
        public IEnumerable<TinTuc> news()
        {
            return db.TinTucs.Where(n => n.TinMoi == true && n.TrangThai == true);
        }
        public IEnumerable<TinTuc> techguild()
        {
            return db.TinTucs.Where(n => n.HuongDanKyThuat == true && n.TrangThai == true);
        }
    }
}