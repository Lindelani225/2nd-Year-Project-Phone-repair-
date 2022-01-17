using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using PhoneR_System.Models;

namespace PhoneR_System.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        PHONEEntities db = new PHONEEntities();
       
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Index(Cust_RegisterModel obj)
        {
            using (PHONEEntities db = new PHONEEntities())
            {
                var cust = (from s in db.Cust_RegisterModel
                            where s.Email == obj.Email && s.Pass == obj.Pass
                            select s).FirstOrDefault();

                var employee = (from s in db.Empl_RegisterModels
                                where s.Email == obj.Email && s.Pass == obj.Pass
                                select s).FirstOrDefault();


                if (cust == null && employee == null)
                {
                    obj.loggInError = "Wrong username or password";
                    return View("Index", obj);
                }

                else
                {

                    if (cust != null)
                    {
                       
                        Session["Customer"] = cust.Email;
                        Session["username"] = cust.FtName;

                        return RedirectToAction("Index", "CustomerDashboard", cust);

                    }

                    else if (employee != null )
                    {
                       var rlemp = (from r in db.Roles
                                    where r.Rol_ID == employee.Rol_ID
                                   select r.Rol).Single();

                        Session["Role"] = rlemp;
                        if(rlemp == "Admin")
                        {
                            Session["Admin"] = employee.Email;
                            return RedirectToAction("Index", "AdminDashboard", employee);
                        }

                        else
                        {
                            Session["Technician"] = employee.Email;
                            return RedirectToAction("Index", "TechnicianDashboard", employee);
                        }
                    }

                    return View(obj);
                }
              

            }
        }
    }
}