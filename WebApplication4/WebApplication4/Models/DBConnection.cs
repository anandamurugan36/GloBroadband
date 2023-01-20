using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class DBConnection
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);
        SqlCommand command = null;
        SqlDataAdapter dataAdapter = null;
        DataTable datatable = null;
        public string Register(Register register)
        {
            command = new SqlCommand("Insert INTO Register(FirstName,LastName,Email,Password) VALUES('" + register.FirstName + "','" + register.LastName + "','" + register.Email + "','" + register.Password + "',1)", connection);
            connection.Open();
            int i = command.ExecuteNonQuery();
            if (i > 0)
                return "Registration successfull";
            else
                return "Registeration failed";
        }
        //public string Login(Login login)
        //{
        //    command = new SqlCommand("select * from Login");
        //    connection.Open();
        //    int i = command.ExecuteNonQuery();
        //    if (i > 0)
        //    {
        //        SqlDataReader rdr = command.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            login.Email = rdr.GetValue(1).ToString();
        //            login.Password = rdr.GetValue(2).ToString();
        //        }
        //        return "Login successfull";
        //    }
        //    else
        //    {
        //        return "Login failed";
        //    }
        //}
        public ApiResponse Login(AdminLogin login)
        {
            ApiResponse apiResponse = new ApiResponse();
            apiResponse.ApiStatus = true;
            apiResponse.Status = true;
            command = new SqlCommand("select * from Login");
            connection.Open();
            int i = command.ExecuteNonQuery();
            if (i>0)
            {
                SqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    login.Email = rdr.GetValue(1).ToString();
                    login.Password = rdr.GetValue(2).ToString();
                }
                return new ApiResponse()
                {
                    ApiStatus = true,
                    Status = true,
                    Message = "Success"
                };
            }
            else
            {
                return new ApiResponse()
                {
                    ApiStatus = false,
                    Status = false,
                    Message = "Failure"
                };
            }
        }
    }
}