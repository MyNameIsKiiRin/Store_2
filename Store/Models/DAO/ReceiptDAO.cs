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
        public string lastid()
        {
            int a = 0;
            List<int> lstid = new List<int>();
            IEnumerable<string> id = from temp in db.PhieuNhaps select temp.MaPN;
            if (id == null) return 1.ToString();
            else
            {
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
        }
    }
}