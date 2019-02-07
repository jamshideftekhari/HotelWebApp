using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelWebApp.Models;

namespace HotelWebApp.Controllers
{
    public class HotelSingelController : Controller
    {
        private HotelSingleDbCotext db = new HotelSingleDbCotext(); 
        // GET: HotelSingel
        public ActionResult Index()
        {
            
            return View(db.Hotels.ToList());
        }
    }
}