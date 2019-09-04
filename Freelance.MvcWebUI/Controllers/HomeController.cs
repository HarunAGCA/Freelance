 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Freelance.MvcWebUI.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return RedirectToAction("index","Projects");
        }
    }
}