using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LxShop.Models.EF;
using PagedList;
using LxShop.Services;

namespace Lx_shop.Areas.Admin.Controllers
{
    public class CustomersController : Controller
    {
        private db_smartphoneEntities db = new db_smartphoneEntities();
        protected ICustomerService _customerService;
        public CustomersController()
        {
            _customerService = new CustomerService();
        }
        // GET: Admin/Customers
        public ActionResult Index()
        {
            //return View(db.Customers.ToList());
            return View();
        }

        // GET: Admin/Customers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = (from C in db.Customers
                         join P in db.Provinces
                         on C.ProvinceId equals P.ProvinceId
                         join D in db.Districts
                        on C.DistrictId equals D.DistrictId
                         select new CustomerModel()
                         {
                             customer = C,
                             province = P,
                             district = D

                         });
            CustomerModel customer = query.Where(n => n.customer.Customer_id == id).FirstOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Customers/Details.cshtml", customer);
        }
        public PartialViewResult _TableView(CustomerModel model)
        {
            ViewBag.CustomerModel = model;
            IPagedList<CustomerModel> data = _customerService.PaggingCustomer(model);
            return PartialView(data);
        }

        // GET: Admin/Customers/Create
        public ActionResult Create()
        {
            ViewBag.ProvinceId = new SelectList(db.Provinces.ToList(), "ProvinceId", "ProvinceName");
        
            return View("~/Areas/Admin/Views/Customers/Create.cshtml");
        }

        public JsonResult getListDistrict(string id)
        {
            return  Json(db.Districts.Where(x => x.ProvinceId == id).ToList(),JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetListDistrictByProvinceId(string id)
        {
            return Json(db.Districts.Where(x => x.ProvinceId == id),JsonRequestBehavior.AllowGet);
        }
        // POST: Admin/Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create( Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            ViewBag.ProvinceId = new SelectList(db.Provinces.ToList(), "ProvinceId", "ProvinceName", customer.ProvinceId);
            return Json(new {data = false },JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Customers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinceId = new SelectList(db.Provinces.ToList(), "ProvinceId", "ProvinceName",customer.ProvinceId);
            ViewBag.DistrictId = new SelectList(db.Districts.ToList(), "DistrictId", "DistrictName", customer.DistrictId);
            return View("~/Areas/Admin/Views/Customers/Edit.cshtml", customer);
        }
        

        // POST: Admin/Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            ViewBag.ProvinceId = new SelectList(db.Provinces.ToList(), "ProvinceId", "ProvinceName", customer.ProvinceId);
            ViewBag.DistrictId = new SelectList(db.Districts.ToList(), "DistrictId", "DistrictName", customer.DistrictId);
            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Customers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Customers/Delete.cshtml", customer);
        }

        // POST: Admin/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return Json(new{data = true},JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
