using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LxShop.Models.EF;
using LxShop.Services;
using PagedList;

namespace Lx_shop.Areas.Admin.Controllers
{
    public class Product_SpecificationsController : Controller
    {
        private db_smartphoneEntities db = new db_smartphoneEntities();
        protected readonly IProduct_SpecificationService _product_SpecificationService;
        public Product_SpecificationsController()
        {
            _product_SpecificationService = new Product_SpecificationService();
        }
        // GET: Admin/Product_Specifications
        public ActionResult Index()
        {
            //return View(db.Product_Specifications.ToList());
            return View();
        }
        public PartialViewResult _TableView(Product_SpecificationModel model)
        {
            ViewBag.Product_SpecificationModel = model;
            IPagedList<Product_SpecificationModel> data = _product_SpecificationService.PaggingProduct_Specification(model);
            return PartialView(data);
        }
        // GET: Admin/Product_Specifications/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = (from P in db.Products
                         join PS in db.Product_Specifications
                         on P.Product_Id equals PS.Product_Id
                         select new Product_SpecificationModel()
                         {
                             _product = P,
                             product_Specifications = PS
                         });

           Product_SpecificationModel product_Specifications = query.Where(n => n.product_Specifications.Specification_Id == id).FirstOrDefault();
            if (product_Specifications == null)
            {
                return HttpNotFound();
            }
            
            return View("~/Areas/Admin/Views/Product_Specifications/Details.cshtml", product_Specifications);
        }

        // GET: Admin/Product_Specifications/Create
        public ActionResult Create()
        {
            ViewBag.Product_Id = new SelectList(db.Products.Where(n=>n.Status ==1), "Product_Id", "Product_Name");
            return View("~/Areas/Admin/Views/Product_Specifications/Create.cshtml");
        }

        // POST: Admin/Product_Specifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create( Product_Specifications product_Specifications)
        {
            if (ModelState.IsValid)
            {
                db.Product_Specifications.Add(product_Specifications);
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            ViewBag.Product_Id = new SelectList(db.Products, "Product_Id", "Product_Name", product_Specifications.Product_Id);
            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Product_Specifications/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Specifications product_Specifications = db.Product_Specifications.Find(id);
            if (product_Specifications == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_Id = new SelectList(db.Products.Where(n=>n.Status==1), "Product_Id", "Product_Name", product_Specifications.Product_Id);
            return View("~/Areas/Admin/Views/Product_Specifications/Edit.cshtml",product_Specifications);
        }

        // POST: Admin/Product_Specifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit( Product_Specifications product_Specifications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Specifications).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { data = true },JsonRequestBehavior.AllowGet);
            }
            ViewBag.Product_Id = new SelectList(db.Products, "Product_Id", "Product_Name", product_Specifications.Product_Id);
            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Product_Specifications/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Specifications product_Specifications = db.Product_Specifications.Find(id);
            if (product_Specifications == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Product_Specifications/Delete.cshtml",product_Specifications);
        }

        // POST: Admin/Product_Specifications/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product_Specifications product_Specifications = db.Product_Specifications.Find(id);
            db.Product_Specifications.Remove(product_Specifications);
            db.SaveChanges();
            return Json(new { data = true },JsonRequestBehavior.AllowGet);
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
