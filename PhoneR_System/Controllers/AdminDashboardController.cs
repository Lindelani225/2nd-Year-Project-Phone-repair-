using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneR_System.Controllers
{
    public class AdminDashboardController : Controller
    {
        // GET: AdminDashboard
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                ViewBag.userAdmin = Session["Admin"];
            }
            return View();
        }
    }
}