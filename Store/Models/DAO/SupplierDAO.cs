using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Models.EF;
namespace Store.Models.DAO
{
    public class SupplierDAO
    {
        DBStore db = null;
        public SupplierDAO()
        { db = new DBStore(); }

        public List<NhaCungCap> sup()
        {
            return db.NhaCungCaps.ToList();
        }

    }
}