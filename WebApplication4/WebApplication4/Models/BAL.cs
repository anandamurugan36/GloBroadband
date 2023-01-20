using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class BAL
    {
        DBConnection db = new DBConnection();
        public string Register(Register register)
        {
            return db.Register(register);
        }
        public string Login(AdminLogin login)
        {
            object obj = new object();
            obj = db.Login(login);
            return obj.ToString();
        }
    }
}