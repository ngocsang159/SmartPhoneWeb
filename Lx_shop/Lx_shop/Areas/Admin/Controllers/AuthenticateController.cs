using LxShop.Commons;
using LxShop.Models.EF;
using LxShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lx_shop.Areas.Admin.Controllers
{
    public class AuthenticateController : Controller
    {
        protected readonly db_smartphoneEntities db = new db_smartphoneEntities();
        private readonly IAccountAdminService _service;
        public AuthenticateController()
        {
            _service = new AccountAdminService();
        }
        // GET: Admin/Authenticate
        public ActionResult Login()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountAdmin model)
        {
           ResponseData<AccountAdmin> res =  _service.CheckLogin(model);
            Session["USER"] = res.Data;
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Login", "Authenticate");
            
        }
        public ActionResult Register()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult Register(AccountAdmin model)
        {
            ResponseData<AccountAdmin> res = new ResponseData<AccountAdmin>();
            bool check = db.AccountAdmins.Where(n => n.Username == model.Username).Count() > 0;
            if(check)
            {
                res.StatusCode = 201;
                res.ErrorMessage = "Tên đăng nhập đã tồn tại, vui lòng nhập tên khác";
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            model.CreateDate= DateTime.Now;
            model.Password = Decryption.GetMD5(model.Password);
            db.AccountAdmins.Add(model);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}