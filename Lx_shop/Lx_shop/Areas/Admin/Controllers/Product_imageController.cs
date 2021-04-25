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
    public class Product_imageController : Controller
    {
        private db_smartphoneEntities db = new db_smartphoneEntities();
        protected readonly IProduct_imageService product_ImageService;
        public Product_imageController()
        {
            product_ImageService = new Product_imageService();
        }

        // GET: Admin/Product_image
        public ActionResult Index()
        {
            //return View(db.Product_image.ToList());
            return View();
        }
        public PartialViewResult _TableView(Product_ImageModel model)
        {
            ViewBag.Product_ImageModel = model;
            IPagedList<Product_ImageModel> data = product_ImageService.PaggingProduct_image(model);
            return PartialView(data);
        }
        // GET: Admin/Product_image/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = (from PI in db.Product_image
                         join P in db.Products
                         on PI.Product_Id equals P.Product_Id

                         select new Product_ImageModel()
                         {
                             product_Image = PI,
                             product = P,
                         });

            Product_ImageModel product_image = query.Where(n => n.product_Image.Image_Id == id).FirstOrDefault();
            if (product_image == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Product_image/Details.cshtml", product_image);
        }

        // GET: Admin/Product_image/Create
        public ActionResult Create()
        {
            ViewBag.Product_Id = new SelectList(db.Products.Where(n => n.Status == 1), "Product_Id", "Product_Name");
            return View("~/Areas/Admin/Views/Product_image/Create.cshtml");
        }

        // POST: Admin/Product_image/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create( Product_image product_image)
        {
            if (ModelState.IsValid)
            {
                db.Product_image.Add(product_image);
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            ViewBag.Product_Id = new SelectList(db.Products, "Product_Id", "Product_Name", product_image.Product_Id);
            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Product_image/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_image product_image = db.Product_image.Find(id);
            if (product_image == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_Id = new SelectList(db.Products.Where(n => n.Status == 1), "Product_Id", "Product_Name",product_image.Product_Id);
            return View("~/Areas/Admin/Views/Product_image/Edit.cshtml",product_image);
        }

        // POST: Admin/Product_image/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit( Product_image product_image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_image).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            ViewBag.Product_Id = new SelectList(db.Products, "Product_Id", "Product_Name", product_image.Product_Id);
            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Product_image/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_image product_image = db.Product_image.Find(id);
            if (product_image == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Product_image/Delete.cshtml",product_image);
        }

        // POST: Admin/Product_image/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product_image product_image = db.Product_image.Find(id);
            db.Product_image.Remove(product_image);
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
