using PhoneR_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneR_System.Controllers
{
    public class ThankYouRequestController : Controller
    {
        // GET: ThankYouRequest
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                ViewBag.username = Session["username"];
            }
            return View();
        }
    }
}