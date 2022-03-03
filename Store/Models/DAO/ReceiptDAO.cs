using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Models.EF;
namespace Store.Models.DAO
{
    public class ReceiptDAO
    {
        DBStore db = null;
        public ReceiptDAO()
        {
            db = new DBStore();
        }
        public bool insert(PhieuNhap entity)
        {
            try
            {
                db.PhieuNhaps.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        
       
    }
}