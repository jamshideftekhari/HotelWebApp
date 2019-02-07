using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace HotelWebApp.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return View();
           // return "This is my default action";
        }

        public string Welcome()
        {
            //return View();
            return "This is welcome action";
        }
    }
}