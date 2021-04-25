using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LxShop.Models.EF;
using LxShop.Commons;
using PagedList;
using LxShop.Services;

namespace Lx_shop.Areas.Admin.Controllers
{
    public class Product_Category_TypeController : Controller
    {
        private db_smartphoneEntities db = new db_smartphoneEntities();
        private readonly IProduct_Category_TypeService _Category_TypeService;
        public Product_Category_TypeController()
        {
            _Category_TypeService = new Product_Category_TypeService();
        }

        // GET: Admin/Product_Category_Type
        public ActionResult Index()
        {
            return View();
            //return View(db.Product_Category_Type.ToList());
        }
        public PartialViewResult _TableView(ProductCategory_Type model)
        {
            ViewBag.ProductCategory_Type = model;
            IPagedList<ProductCategory_Type> data = _Category_TypeService.PaggingCategoryType(model);
            return PartialView(data);
        }
        // GET: Admin/Product_Category_Type/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = (from PC in db.Product_Category
                         join PCT in db.Product_Category_Type
                         on PC.Product_CategoryId equals PCT.Product_CategoryId
                         select new ProductCategory_Type() { Product_Category = PC, Product_Category_Type = PCT });
            ProductCategory_Type product_Category_Type = query.Where(n => n.Product_Category_Type.Product_Category_TypeId == id).FirstOrDefault();
            if (product_Category_Type == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Product_Category_Type/Details.cshtml", product_Category_Type);
        }

        // GET: Admin/Product_Category_Type/Create
        public ActionResult Create()
        {
            ////lấy toàn bộ danh mục
            //List<Product_Category> cate = db.Product_Category.ToList();
            ////tạo selectList
            //SelectList catelist = new SelectList(cate, "Product_CategoryId", "Product_CategoryName");
            ////set vào viewbag
            //ViewBag.CategoryList = catelist;
            ViewBag.Product_CategoryId = new SelectList(db.Product_Category.Where(n=>n.Status == 1), "Product_CategoryId", "Product_CategoryName");
            return View("~/Areas/Admin/Views/Product_Category_Type/Create.cshtml");
        }

        // POST: Admin/Product_Category_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product_Category_Type product_Category_Type)
        {
            if (ModelState.IsValid)
            {
                db.Product_Category_Type.Add(product_Category_Type);
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            ViewBag.Product_CategoryId = new SelectList(db.Product_Category, "Product_CategoryId", "Product_CategoryName", product_Category_Type.Product_CategoryId);
            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Product_Category_Type/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Category_Type product_Category_Type = db.Product_Category_Type.Find(id);
            if (product_Category_Type == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_CategoryId = new SelectList(db.Product_Category.Where(n=>n.Status == 1), "Product_CategoryId", "Product_CategoryName", product_Category_Type.Product_CategoryId);
            return View("~/Areas/Admin/Views/Product_Category_Type/Edit.cshtml", product_Category_Type);
        }
        // POST: Admin/Product_Category_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Product_Category_Type product_Category_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Category_Type).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            ViewBag.Product_CategoryId = new SelectList(db.Product_Category, "Product_CategoryId", "Product_CategoryName", product_Category_Type.Product_CategoryId);
            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Product_Category_Type/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Category_Type product_Category_Type = db.Product_Category_Type.Find(id);
            if (product_Category_Type == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Product_Category_Type/Delete.cshtml", product_Category_Type);
        }

        // POST: Admin/Product_Category_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product_Category_Type product_Category_Type = db.Product_Category_Type.Find(id);
            db.Product_Category_Type.Remove(product_Category_Type);
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
