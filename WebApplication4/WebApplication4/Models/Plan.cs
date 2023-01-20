using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Plan
    {
        public int Plan_Id { get; set; }
        public string Plan_Details { get; set; }
        public string Created_by { get; set; }
        public string Created_date { get; set; }
        public string IsActive { get; set; }
    }
    public class PlanDetails
    {
        public List<Plan> Plan { get; set; }
    }
}