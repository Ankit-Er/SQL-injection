using Sql_Inject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sql_Inject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String UserID, String Password)
        {
            BussLayer buss = new BussLayer();
            String UName = buss.getRecords(UserID, Password);
            if (!String.IsNullOrEmpty(UName))
            {
                return RedirectToAction("LoginPanel", new { UserName = UName });
            }

            return View();
        }

        public ActionResult LoginPanel()
        {
            ViewBag.UserName = Request.QueryString["UserName"].ToString();
            return View();
        }

    }
}