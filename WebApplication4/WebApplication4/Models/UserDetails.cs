using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class UserDetails
    {
        public int Admin_Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Aadhar { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_date { get; set; }
        public string IsActive { get; set; }
        public int Location_Id { get; set; }
        public string IsLogin { get; set; }
        public int Salary_Id { get; set; }
        public int Plan_Id { get; set; }
    }
    public class UserData
    {
        public string Message { get; set; }
    }
    public class GetUserData
    {
        public List<UserDetails> UserDetails { get; set; }
    }
}