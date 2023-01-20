using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Salary
    {
        public int Slary_Id { get; set; }
        public string Salary_Details { get; set; }
        public string Created_by { get; set; }
        public string Created_date { get; set; }
        public string IsActive { get; set; }
    }

    public class SalaryDetails
    {
        public List<Salary> Salary { get; set; }
    }
}