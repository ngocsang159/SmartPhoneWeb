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
using LxShop.Commons;

namespace Lx_shop.Areas.Admin.Controllers
{
    public class Product_CategoryController : Controller
    {
        private db_smartphoneEntities db = new db_smartphoneEntities();
        private readonly IProduct_categoryService _ProductCategory;
        public Product_CategoryController()
        {
            _ProductCategory = new Product_CategoryService();
        }

        // GET: Admin/Product_Category
        public ActionResult Index()
        {
            return View();
            //return View(db.Product_Category.ToList());
        }
        public PartialViewResult _TableView(Product_Category model)
        {
            ViewBag.Product_Category = model;
            IPagedList<Product_Category> data = _ProductCategory.PaggingProduct_category(model);
            return PartialView(data);
        }

        // GET: Admin/Product_Category/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Category product_Category = db.Product_Category.Find(id);
            if (product_Category == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Product_Category/Details.cshtml", product_Category);
        }

        // GET: Admin/Product_Category/Create
        public ActionResult Create()
        {
            return View("~/Areas/Admin/Views/Product_Category/Create.cshtml");
        }

        // POST: Admin/Product_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stt,Product_CategoryId,Product_CategoryName,Product_id,Status,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsDeleted")] Product_Category product_Category)
        {
            if (ModelState.IsValid)
            {
                ResponseData<Product_Category> res = new ResponseData<Product_Category>();
                bool check = db.Product_Category.Where(n => n.Product_CategoryId == product_Category.Product_CategoryId).Count() > 0;
                if(check)
                {
                    res.StatusCode = 201;
                    res.ErrorMessage = "Id đã tồn tại! Vui lòng nhập Id khác";
                    return Json(res);
                }
                if(product_Category.CreatedDate == null)
                {
                    product_Category.CreatedDate = DateTime.Now;
                    
                }
                db.Product_Category.Add(product_Category);
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { data = false },JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Product_Category/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Category product_Category = db.Product_Category.Find(id);
            if (product_Category == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Product_Category/Edit.cshtml", product_Category);
        }

        // POST: Admin/Product_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stt,Product_CategoryId,Product_CategoryName,Product_id,Status,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsDeleted")] Product_Category product_Category)
        {
            if (ModelState.IsValid)
            {
                if (product_Category.UpdatedDate == null)
                {
                    product_Category.UpdatedDate = DateTime.Now;
                }
                var obj = db.Product_Category.Find(product_Category.Product_CategoryId);
                obj.Product_CategoryName = product_Category.Product_CategoryName;
                obj.Status = product_Category.Status;
                obj.CreatedDate = product_Category.CreatedDate;
                obj.CreatedBy = product_Category.CreatedBy;
                obj.UpdatedDate = product_Category.UpdatedDate;
                obj.UpdatedBy = product_Category.UpdatedBy;
                obj.IsDeleted = product_Category.IsDeleted;
               
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Product_Category/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Category product_Category = db.Product_Category.Find(id);
            if (product_Category == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Product_Category/Delete.cshtml", product_Category);
        }

        // POST: Admin/Product_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string Product_CategoryId)
        {
            Product_Category product_Category = db.Product_Category.Find(Product_CategoryId);
            db.Product_Category.Remove(product_Category);
            db.SaveChanges();
            return Json(new { data = true }, JsonRequestBehavior.AllowGet);
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
