using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StartProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: First
        public ActionResult Index()
        {
            //codigo da regra de negôcio da aplicação
            return View();
        }
    }
}