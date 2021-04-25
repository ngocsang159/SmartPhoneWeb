using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lx_shop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["USER"] == null)
            {
                return RedirectToAction("Login", "Authenticate");
            }
            return View();
        }
    }
}