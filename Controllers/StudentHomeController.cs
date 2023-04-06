using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam_Planner.Controllers
{
    public class StudentHomeController : Controller
    {
        // GET: StudentHome
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
    }
}