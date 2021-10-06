using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Models.EF;
namespace Store.Models.DAO
{
    public class SlideDAO
    {
        DBStore db = null;
        
        public SlideDAO()
        {
            db = new DBStore();
        }
        public IEnumerable<Slide> slide()
        {
            return db.Slides;
        }
    }
}