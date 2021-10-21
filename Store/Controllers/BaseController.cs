using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        
        protected void SetAlert(string mess, string type)
        {
            TempData["AlertMessage"] = mess;
            if (type == "seccess")
            {
                TempData["AlertType"] = "alert-success";
            }
            if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
            if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
        }
    }
}