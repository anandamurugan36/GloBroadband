using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WebApplication4.Controllers
{
    public class AdminLoginController : ApiController
    {
        [System.Web.Http.HttpPost]
        public IHttpActionResult PostAdmin(FromRam fromRam)
        {
            AdminLogin adminLogin = new AdminLogin();
            ResponseData data = new ResponseData();
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select * from AdminLogin where Mobile = '" + fromRam.Mobile+ "' AND Password = '" + fromRam.Password + "' AND Location_Id = (select Location_Id from Location where Location_Id = " + fromRam.Location_Id+")";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataReader rdr = sqlcomm.ExecuteReader();
            if (rdr.Read() == true)
            {
                adminLogin.Admin_Id = Convert.ToInt32(rdr.GetValue(0));
                adminLogin.Name = rdr.GetValue(1).ToString();
                adminLogin.Email = rdr.GetValue(2).ToString();
                adminLogin.Password = rdr.GetValue(3).ToString();
                adminLogin.Address = rdr.GetValue(4).ToString();
                adminLogin.Mobile = rdr.GetValue(5).ToString();
                adminLogin.Created_by = rdr.GetValue(6).ToString();
                adminLogin.Created_date = rdr.GetValue(7).ToString();
                adminLogin.IsActive = rdr.GetValue(8).ToString();
                adminLogin.Location_Id = Convert.ToInt32(rdr.GetValue(9));
                data.Admin = adminLogin;
                data.Message = "Success";
                return Ok(data);
            }
            else
            {
                data.Message = "Failure";
                return Ok(data);
            }
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult Update()
        {
            return Ok();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetLocation()
        {
            List<Location> locationList = new List<Location>();
            Root root = new Root();
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select * from Location where IsActive=1";
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

    }
}