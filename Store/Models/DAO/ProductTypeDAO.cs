using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Models.EF;
namespace Store.Models.DAO
{
    public class ProductTypeDAO
    {
        DBStore db = null;
        public ProductTypeDAO()
        {
            db = new DBStore(); 
        }
        public IEnumerable<LoaiSanPham> type()
        {
            return db.LoaiSanPhams;
        }
    }
}