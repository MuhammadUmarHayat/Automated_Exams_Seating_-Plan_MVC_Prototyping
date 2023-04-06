using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam_Planner.Controllers
{
    public class FacultyHomeController : Controller
    {
        // GET: FacultyHome
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("Index");
            }
        }
        public ActionResult Logout()
        {
            ViewBag.message = "You are logot out successfully!";
            return View();
        }  

        }
}