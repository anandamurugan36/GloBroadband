using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Location
    {
        public int Location_Id { get; set; }
        public string Pincode { get; set; }
        public string Town { get; set; }
        public string Created_by { get; set; }
        public string Created_date { get; set; }
        public string IsActive { get; set; }
    }

    public class Root
    {
        public List<Location> Location { get; set; }
    }
}