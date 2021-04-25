using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LxShop.Models.EF;
using LxShop.Services;
using LxShop.Commons;
using System.Web.Security;

namespace Lx_shop.Controllers
{
    public class HeThongController : Controller
    {
        // GET: HeThong
        protected readonly db_smartphoneEntities db = new db_smartphoneEntities();
        protected ICustomerService _customerService;
        public HeThongController()
        {
            _customerService = new CustomerService();
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer customer )
        {
            ResponseData<Customer> res = _customerService.CheckLogin(customer);
            Session["CUSTOMER"] = res.Data;
            return Json(res,JsonRequestBehavior.AllowGet);
        }
       public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            ResponseData<Customer> res = new ResponseData<Customer>();
            bool check = db.Customers.Where(n => n.email == customer.email).Count() > 0;
            if (check)
            {
                res.StatusCode = 201;
                res.ErrorMessage = "Email đã tồn tại!";
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            customer.CreatedDate = DateTime.Now;
            customer.Password = Decryption.GetMD5(customer.Password);
            var obj = new Customer();
            obj.Customer_name = customer.Customer_name;
            obj.phone = customer.phone;
            obj.email = customer.email;
            obj.Password = customer.Password;
            obj.Status = 1;
            db.Customers.Add(obj);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
            
        }
    }
}