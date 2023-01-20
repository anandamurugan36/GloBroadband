using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using System.Net.Http;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Root loc = null;
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:62135");

            var data = httpClient.GetAsync("location");
            data.Wait();

            var dataRead = data.Result;
            if(dataRead.IsSuccessStatusCode)
            {
                var results = dataRead.Content.ReadAsAsync<Root>();
                results.Wait();
                loc = results.Result;
            }
            return View(loc);
        }

        //public ActionResult Post()
        //{
        //    AdminLogin adminLogin = null;
        //    HttpClient httpClient = new HttpClient();
        //    httpClient.BaseAddress = new Uri("http://localhost:62135/Api/");

        //    var data = httpClient.PostAsJsonAsync("http://localhost:62135/Api/", "AdminLogin");
        //    data.Wait();

        //    var dataRead = data.Result;
        //    if (dataRead.IsSuccessStatusCode)
        //    {
        //        var results = dataRead.Content.ReadAsAsync<AdminLogin>();
        //        results.Wait();
        //        adminLogin = results.Result;
        //    }
        //    return View(adminLogin);
        //}
    }
}
