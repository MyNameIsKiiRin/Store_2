using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Models.EF;
namespace Store.Models.DAO
{
    public class ProducerDAO
    {
        DBStore db = null;

        public ProducerDAO()
        {
            db = new DBStore();
        }
        public List<NhaSanXuat> procer()
        {
            return db.NhaSanXuats.ToList();
        }
    }
}