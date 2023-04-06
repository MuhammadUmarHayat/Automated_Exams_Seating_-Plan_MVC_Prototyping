using Exam_Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam_Planner.Controllers
{
    public class TimteTableController : Controller
    {
        DAL dal = new DAL();
        // GET: TimteTable
        public ActionResult Index()
        {
            
            var dt = dal.TimeTableList();
            List<TimteTableModel> timetableList = new List<TimteTableModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TimteTableModel tm = new TimteTableModel();
               tm.EmpName = dt.Rows[i]["EmpName"].ToString();
                tm.EmpId = dt.Rows[i]["EmpId"].ToString();

                tm.Date = dt.Rows[i]["Date"].ToString();
                tm.Time = dt.Rows[i]["Time"].ToString();
                tm.Status = dt.Rows[i]["Status"].ToString();




                timetableList.Add(tm);
            }
            return View(timetableList);
        }
        //GET: Add Student
        public ActionResult AddTimeTable()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTimeTable(TimteTableModel tm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  
                    string empName = tm.EmpName.ToString();
                    string empId = tm.EmpId.ToString();
                    string date = tm.Date.ToString();
                    string time = tm.Time.ToString();
                    string roomno = tm.RoomNo.ToString();
                    string status = "active";
                    Boolean result = dal.saveTimeTable(empName, empId, date, time, roomno, status);
                    if (result)
                    {
                        ViewBag.Message = "Details added successfully";
                    }

                }
                else
                {
                    ViewBag.Message = "Please enter corract values";
                    return View();
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

    }
}