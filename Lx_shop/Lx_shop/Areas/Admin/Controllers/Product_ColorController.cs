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
    public class Product_ColorController : Controller
    {
        private db_smartphoneEntities db = new db_smartphoneEntities();
        protected readonly IProduct_ColorService _product_ColorService;
        public Product_ColorController()
        {
            _product_ColorService = new Product_ColorService();
        }


        // GET: Admin/Product_Color
        public ActionResult Index()
        {
            return View();
            //return View(db.Product_Color.ToList());
        }
        public PartialViewResult _TableView(Product_ColorModel model)
        {
            ViewBag.Product_ColorModel = model;
            IPagedList<Product_ColorModel> data = _product_ColorService.PaggingProduct_Color(model);
            return PartialView(data);
        }
        // GET: Admin/Product_Color/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = (from PC in db.Product_Color
                         join P in db.Products
                         on PC.Product_Id equals P.Product_Id
                         select new Product_ColorModel()
                         {
                             product_color = PC,
                             product = P
                         });

            Product_ColorModel product_Color = query.Where(n => n.product_color.Color_Id == id).FirstOrDefault();
            if (product_Color == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Product_Color/Details.cshtml", product_Color);
        }

        // GET: Admin/Product_Color/Create
        public ActionResult Create()
        {
            ViewBag.Product_Id = new SelectList(db.Products.Where(n => n.Status == 1), "Product_Id", "Product_Name");
            return View("~/Areas/Admin/Views/Product_Color/Create.cshtml");
        }

        // POST: Admin/Product_Color/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]

        public ActionResult Create( Product_Color product_Color)
        {
            if (ModelState.IsValid)
            {
                db.Product_Color.Add(product_Color);
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            ViewBag.Product_Id = new SelectList(db.Products.Where(n=>n.Status == 1), "Product_Id", "Product_Name", product_Color.Product_Id);
            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Product_Color/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Color product_Color = db.Product_Color.Find(id);
            if (product_Color == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_Id = new SelectList(db.Products.Where(n => n.Status == 1), "Product_Id", "Product_Name", product_Color.Product_Id);
            return View("~/Areas/Admin/Views/Product_Color/Edit.cshtml", product_Color);
        }

        // POST: Admin/Product_Color/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Product_Color product_Color)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Color).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            ViewBag.Product_Id = new SelectList(db.Products, "Product_Id", "Product_Name", product_Color.Product_Id);
            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Product_Color/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Color product_Color = db.Product_Color.Find(id);
            if (product_Color == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Product_Color/Delete.cshtml", product_Color);
        }

        // POST: Admin/Product_Color/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product_Color product_Color = db.Product_Color.Find(id);
            db.Product_Color.Remove(product_Color);
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
