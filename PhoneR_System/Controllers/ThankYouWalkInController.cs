using PhoneR_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;

namespace PhoneR_System.Controllers
{
    public class ThankYouWalkInController : Controller
    {
     
        // GET: ThankYouWalkIn
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Index(Cust_WalkIn obj)
        {
            if (Session["username"] != null)
            {
                ViewBag.username = Session["username"];
            }
            return View(obj);
        }
    }
}