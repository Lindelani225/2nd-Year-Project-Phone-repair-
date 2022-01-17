using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneR_System.Controllers
{
    public class CustomerDashboardController : Controller
    {
        // GET: CustomerDashboard
        public ActionResult Index()
        {
            if (Session["Customer"]!= null)
            {
                ViewBag.User = Session["Customer"];
            }
            return View();
        }
    }
}