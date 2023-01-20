using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class AdminLogin
    {
        public int Admin_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Created_by { get; set; }
        public string Created_date { get; set; }
        public string IsActive { get; set; }
        public int Location_Id { get; set; }
    }
    public class ResponseData
    {
        public AdminLogin Admin { get; set; }
        public string Message { get; set; }
    }
}