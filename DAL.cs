﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exam_Planner
{
    public class DAL
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=exam_prototypingDB;Integrated Security=True";
            con = new SqlConnection(constr);


        }
/// <summary>
/// Faculty information
/// </summary>
/// <param name="EmpID"></param>
/// <param name="full_name"></param>
/// <param name="password"></param>
/// <param name="designation"></param>
/// <param name="date_of_appointment"></param>
/// <param name="status"></param>
/// <param name="emp_type"></param>
/// <param name="address"></param>
/// <returns></returns>
        public Boolean saveFaculty(string EmpID, string full_name, string password, string designation, string date_of_appointment, string status, string emp_type, string address)
        {
            connection();
            string query = "insert into employees(EmpID,full_name,password,designation,date_of_appointment,status,emp_type,address) values('"+EmpID+"','"+full_name+"','"+password+"','"+designation+"','"+date_of_appointment+"','"+status+"','"+emp_type+"','"+address+"')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();//insert data into table
            con.Close();
            return true;
        }

        public DataTable FacultyList()
        {
            connection();
            con.Open();
            string query = "select * from employees";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            return dt;


        }
        public DataTable getFaculty(int id)
        {
            connection();
            con.Open();
            string query = "select * from employees where EmpID='" + id + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            return dt;


        }
        public bool isFaculty(string id,string password)
        {
            connection();
            con.Open();
            string query = "select * from employees where EmpID='" + id + "' and password='" + password + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            if (dt.Rows.Count>0)
            {
                return true;
            }
            return false;


        }
        public bool isStudent(string id, string password)
        {
           
            connection();
            con.Open();
            string query = "select * from students where studentid='" + id + "' and password='" + password + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;


        }
        public bool deleteFaculty(string id)
        {
            connection();

            string query = "delete from employees where EmpID='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();//delete data into table
            con.Close();
            return true;


        }
        public bool updateFaculty(string EmpID, string full_name, string designation, string date_of_appointment, string address)
        {
            connection();
            string query = "update employees set full_name ='" + full_name + "', designation='" + designation + "',date_of_appointment='"+ date_of_appointment + "', address='"+ address + "' where EmpID='" + EmpID + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();//update data into table
            con.Close();
            return true;

        }
        ///end of faculty information
        ///
        public Boolean saveAaccounts(string studentid, string program, string amount, string month, string date, string status, string receivedBy)
        {
            connection();
            string query = "insert into accounts(studentid,program,amount,month,date,status,receivedBy) values('" + studentid + "','" + program + "','" + amount + "','" + month + "','" + date + "','" + status + "','"  + receivedBy + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();//insert data into table
            con.Close();
            return true;
        }
        /// <summary>
        /// /Student Information
        /// </summary>
        /// <param name="studentid"></param>
        /// <param name="name"></param>
        /// <param name="program"></param>
        /// <param name="rollnumber"></param>
        /// <param name="password"></param>
        /// <param name="gender"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public Boolean saveStudent(string studentid, string name, string program, string rollnumber, string password, string gender, string status)
        {
            connection();
            string query = "insert into students(studentid,name,program,rollnumber,password,gender,status) values('" + studentid + "','" + name + "','" + program + "','" + rollnumber + "','" + password + "','" + gender + "','" + status + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();//insert data into table
            con.Close();
            return true;
        }
        public DataTable studentList()
        {
            connection();
            con.Open();
            string query = "select * from students";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            da.Fill(dt);
            return dt;
       

        }
        public DataTable getStudent(int id)
        {
            connection();
            con.Open();
            string query = "select * from students where studentid='"+id+"'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            return dt;


        }

        public bool deleteStudent(string id)
        {
            connection();
          
            string query = "delete from students where studentid='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();//insert data into table
            con.Close();
            return true;


        }
        public bool updateStudent(string studentid, string name, string program, string rollnumber)
        {
            connection();
            string query = "update students set name='"+name+ "', program='"+ program + "', rollnumber='"+ rollnumber + "' where studentid='" + studentid + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();//insert data into table
            con.Close();
            return true;

        }
        ///////end of student
        
        
        /// <summary>
        /// Room or Examination hall information
        /// </summary>
        /// <param name="roomNo"></param>
        /// <param name="floor"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public Boolean saveRoom(string roomNo, string floor, string capacity)
        {
            connection();
            string query = "insert into rooms(roomNo,floor,capacity) values('" + roomNo + "','" + floor + "','" + capacity + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();//insert data into table
            con.Close();
            return true;
        }
        public DataTable RoomsList()
        {
            connection();
            con.Open();
            string query = "select * from rooms";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            return dt;


        }
        public DataTable getRoom(int id)
        {
            connection();
            con.Open();
            string query = "select * from rooms where roomNo='" + id + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            return dt;


        }

        public bool deleteRoom(string id)
        {
            connection();

            string query = "delete from rooms where roomNo='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();//delete data into table
            con.Close();
            return true;


        }
        public bool updateRoom(string roomNo, string floor, string capacity)
        {
            connection();
            string query = "update rooms set floor='" + floor + "', capacity='" + capacity + "' where roomNo='" + roomNo + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();//insert data into table
            con.Close();
            return true;

        }
        /////// end of room information

        ///
        /// Time table methods
        ///

        public Boolean saveTimeTable(string empName, string empId, string roomno, string date, string time, string status)
        {
            connection();
            string query = "insert into time_tables(empName,empId,roomno,date,time,status) values('" + empName + "','" + empId + "','" + roomno + "','" + date + "','" + time + "','" + status + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();//insert data into table
            con.Close();
            return true;
        }
        public DataTable TimeTableList()
        {
            connection();
            con.Open();
            string query = "select * from time_tables";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            return dt;


        }
    }
}