using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class GloController : ApiController
    {
        [HttpGet]
        [Route("api/location")]
        public IHttpActionResult GetLocation()
        {

            List<Location> locationList = new List<Location>();
            Root root = new Root();
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select * from location where IsActive=1";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataReader rdr = sqlcomm.ExecuteReader();
            while (rdr.Read())
            {
                Location location = new Location();
                location.Location_Id = Convert.ToInt32(rdr.GetValue(0));
                location.Pincode = rdr.GetValue(1).ToString();
                location.Town = rdr.GetValue(2).ToString();
                location.Created_by = rdr.GetValue(3).ToString();
                location.Created_date = rdr.GetValue(4).ToString();
                location.IsActive = rdr.GetValue(5).ToString();
                locationList.Add(location);
            }
            root.Location = locationList;
            return Ok(root);
        }

        [HttpGet]
        [Route("api/salary")]
        public IHttpActionResult GetSalary()
        {
            List<Salary> SalaryList = new List<Salary>();
            SalaryDetails salaryDetails = new SalaryDetails();
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select * from salary where IsActive=1";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataReader rdr = sqlcomm.ExecuteReader();
            while (rdr.Read())
            {
                Salary salary = new Salary();
                salary.Slary_Id = Convert.ToInt32(rdr.GetValue(0));
                salary.Salary_Details = rdr.GetValue(1).ToString();
                salary.Created_by = rdr.GetValue(2).ToString();
                salary.Created_date = rdr.GetValue(3).ToString();
                salary.IsActive = rdr.GetValue(4).ToString();
                SalaryList.Add(salary);
            }
            salaryDetails.Salary = SalaryList;
            return Ok(salaryDetails);
        }

        [HttpGet]
        [Route("api/plan")]
        public IHttpActionResult GetPlan()
        {
            List<Plan> planList = new List<Plan>();
            PlanDetails planDetails = new PlanDetails();
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select * from plans where IsActive=1";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataReader rdr = sqlcomm.ExecuteReader();
            while (rdr.Read())
            {
                Plan plan = new Plan();
                plan.Plan_Id = Convert.ToInt32(rdr.GetValue(0));
                plan.Plan_Details = rdr.GetValue(1).ToString();
                plan.Created_by = rdr.GetValue(2).ToString();
                plan.Created_date = rdr.GetValue(3).ToString();
                plan.IsActive = rdr.GetValue(4).ToString();
                planList.Add(plan);
            }
            planDetails.Plan = planList;
            return Ok(planDetails);
        }

        [System.Web.Http.HttpPost]
        [Route("api/admin")]
        public IHttpActionResult PostAdmin(FromRam fromRam)
        {
            AdminLogin adminLogin = new AdminLogin();
            ResponseData data = new ResponseData();
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            //string sqlquery = "select Mobile, Password from AdminLogin where Mobile = '" + fromRam.Mobile + "' AND Password = '" + fromRam.Password.ToLower();
            string sqlquery = "select Mobile, Password from AdminLogin";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataReader rdr = sqlcomm.ExecuteReader();
            if (rdr.Read())
            {
                string mobile = rdr[0].ToString();
                string pasword = rdr[1].ToString();
                if(mobile.Equals(fromRam.Mobile) && pasword.Equals(fromRam.Password))
                {
                    data.Message = "login Success";
                    return Ok(data);
;                }
                //adminLogin.Admin_Id = Convert.ToInt32(rdr.GetValue(0));
                //adminLogin.Name = rdr.GetValue(1).ToString();
                //adminLogin.Email = rdr.GetValue(2).ToString();
                //adminLogin.Password = rdr.GetValue(3).ToString();
                //adminLogin.Address = rdr.GetValue(4).ToString();
                //adminLogin.Mobile = rdr.GetValue(5).ToString();
                //adminLogin.Created_by = rdr.GetValue(6).ToString();
                //adminLogin.Created_date = rdr.GetValue(7).ToString();
                //adminLogin.IsActive = rdr.GetValue(8).ToString();
                //adminLogin.Location_Id = Convert.ToInt32(rdr.GetValue(9));
                //data.Admin = adminLogin;
                //data.Message = "Success";
                data.Message = "login Failure";
                return Ok(data);
            }
            //else
            //{
            //    data.Message = "Failure";
            //    return Ok(data);
            //}
            return Ok(data);
        }

        [System.Web.Http.HttpPost]
        [Route("api/adduser")]
        public IHttpActionResult AddAgent(UserDetails userDetailsInput)
        {
            UserDetails userDetails = new UserDetails();
            UserData data = new UserData();
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "INSERT INTO Users(Name,Email,Password,Address,Mobile,Aadhar,created_by,Created_date,IsActive,Location_Id,Admin_Id,IsLogin,Salary_Id,Plan_Id)" +
                "VALUES('" + userDetailsInput.UserName + "', '" + userDetailsInput.Email + "', '" + userDetailsInput.Password + "', '" + userDetailsInput.Address + "', '" + userDetailsInput.Mobile + "', '" + userDetailsInput.Aadhar + "', '" + userDetailsInput.Created_by + "', '" + userDetailsInput.Created_date + "', 1, '" + userDetailsInput.Location_Id + "', '" + userDetailsInput.Admin_Id + "', '" + userDetailsInput.IsLogin + "', '" + userDetailsInput.Salary_Id + "', '" + userDetailsInput.Plan_Id + "')";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.ExecuteReader();
            data.Message = "User added successfully";
            return Ok(data);
        }

        [HttpGet]
        [Route("api/getallusers")]
        public IHttpActionResult GetAllUsers()
        {

            List<UserDetails> userList = new List<UserDetails>();
            GetUserData userData = new GetUserData();
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select * from users where IsActive=1";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataReader rdr = sqlcomm.ExecuteReader();
            while (rdr.Read())
            {
                UserDetails userDetails = new UserDetails();
                userDetails.UserId = Convert.ToInt32(rdr.GetValue(0));
                userDetails.UserName = rdr.GetValue(1).ToString();
                userDetails.Email = rdr.GetValue(2).ToString();
                userDetails.Password = rdr.GetValue(3).ToString();
                userDetails.Address = rdr.GetValue(4).ToString();
                userDetails.Mobile = rdr.GetValue(5).ToString();
                userDetails.Aadhar = rdr.GetValue(6).ToString();
                userDetails.Created_by = rdr.GetValue(7).ToString();
                userDetails.Created_date = (DateTime)rdr.GetValue(8);
                userDetails.IsActive = rdr.GetValue(9).ToString();
                userDetails.Location_Id = Convert.ToInt32(rdr.GetValue(10));
                userDetails.Admin_Id = Convert.ToInt32(rdr.GetValue(11));
                userDetails.IsLogin = rdr.GetValue(12).ToString();
                userDetails.Salary_Id = Convert.ToInt32(rdr.GetValue(13));
                userDetails.Plan_Id = Convert.ToInt32(rdr.GetValue(14));
                userList.Add(userDetails);
            }
            userData.UserDetails = userList;
            return Ok(userData);
        }

        [System.Web.Http.HttpPut]
        [Route("api/update")]
        public IHttpActionResult Update()
        {
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        [Route("api/delete")]
        public IHttpActionResult Delete()
        {
            return Ok();
        }
    }
}
