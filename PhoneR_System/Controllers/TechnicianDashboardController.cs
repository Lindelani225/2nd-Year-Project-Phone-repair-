using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneR_System.Controllers
{
    public class TechnicianDashboardController : Controller
    {
        // GET: TechnicianDashboard
        public ActionResult Index()
        {
            if (Session["Technician"] != null)
            {
                ViewBag.userTech = Session["Technician"];
            }
            return View();
        }
    }
}