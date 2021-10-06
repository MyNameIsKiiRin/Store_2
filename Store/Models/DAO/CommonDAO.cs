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
    }

}