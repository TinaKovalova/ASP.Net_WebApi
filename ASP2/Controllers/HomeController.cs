using ASP2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ASP2.Controllers
{
    public class HomeController : Controller
    {
        private string apiPrivate24 = "https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5";
        public IEnumerable<ExchangeCourse> ExchangeCourses { get; set; }
       
        public ActionResult Index()
        {
            ExchangeCourses = this.GetCourses();
            return View(ExchangeCourses);
        }
        private IEnumerable<ExchangeCourse> GetCourses(){
            WebClient webClient = new WebClient();
            string json = webClient.DownloadString(apiPrivate24);
            var courses = JsonConvert.DeserializeObject<List<ExchangeCourse>>(json);
            return courses;
        }
    }
}