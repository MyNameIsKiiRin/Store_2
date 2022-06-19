﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models.DAO;
using Store.Models.EF;

namespace Store.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ThanhVien tv)
        {
            if (ModelState.IsValid)
            {
                ThanhVien mem = new ThanhVienDAO().login(tv);
                if (mem!=null)
                {
                    Session["Customer"] = mem;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Register(ThanhVien tv)
        {
            if (ModelState.IsValid)
            {
                var check = new ThanhVienDAO().register(tv);
                if (check == true)
                {
                    return RedirectToAction("Login", "Account");
                } 
            } 
            return View(); 
        }
    }
}