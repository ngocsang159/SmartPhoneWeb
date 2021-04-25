using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LxShop.Commons;
using LxShop.Models.EF;
using LxShop.Services;
using PagedList;

namespace Lx_shop.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private db_smartphoneEntities db = new db_smartphoneEntities();
        protected readonly IProductService _productService;
        public ProductsController()
        {
            _productService = new ProductService();
        }
        // GET: Admin/Products
        public ActionResult Index()
        {
            return View();
            //return View(db.Products.ToList());
        }

        public PartialViewResult _TableView(ProductModel model)
        {
            ViewBag.ProductModel = model;
            IPagedList<ProductModel> data = _productService.PaggingProduct(model);
            return PartialView(data);
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);
            var query = (from P in db.Products
                         join PCT in db.Product_Category_Type
                         on P.Product_Category_TypeId equals PCT.Product_Category_TypeId
                         join B in db.Brands
                         on P.Brand_id equals B.Brand_id
                         select new ProductModel()
                         {
                             Product = P,
                             Product_Category_Type = PCT,
                             Brand = B
                         });
            ProductModel product = query.Where(n => n.Product.Product_Id == id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Products/Details.cshtml", product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            //List<Product_Category_Type> cateType = db.Product_Category_Type.ToList();
            //SelectList cateTypeList = new SelectList(cateType, "Product_Category_TypeId", "Product_Category_TypeName");
            ViewBag.Product_Category_TypeId = new SelectList(db.Product_Category_Type.Where(n => n.Status == 1), "Product_Category_TypeId", "Product_Category_TypeName");

            ViewBag.Brand_id = new SelectList(db.Brands.Where(n => n.Status == 1), "Brand_id", "Brand_name");
            return View("~/Areas/Admin/Views/Products/Create.cshtml");
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product product /*HttpPostedFileBase ImgaeAvatar*/)
        {
            if (ModelState.IsValid)
            {
                #region postfile
                //string fname;
                //var path = Server.MapPath("~/Uploads/images/" + Path.GetFileName(ImgaeAvatar.FileName));
                //ImgaeAvatar.SaveAs(path);
                //product.ImgaeAvatar = $@"~/Uploads/images/{ImgaeAvatar.FileName}";

                //if (Request.Files.Count > 0)
                //{
                //    try
                //    {
                //        //  Get all files from Request object  
                //        HttpFileCollectionBase files = Request.Files;
                //        for (int i = 0; i < files.Count; i++)
                //        {
                //            //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                //            //string filename = Path.GetFileName(Request.Files[i].FileName);  

                //            HttpPostedFileBase file = files[i];
                //            string fname;
                //            // Checking for Internet Explorer  
                //            if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                //            {
                //                string[] testfiles = file.FileName.Split(new char[] { '\\' });
                //                fname = testfiles[testfiles.Length - 1];
                //            }
                //            else
                //            {
                //                fname = file.FileName;
                //            }

                // Get the complete folder path and store the file inside it. 

                //fname = DateTime.Now.ToString("yyyyMMddhhmmss") + product.ImgaeAvatar;
                //var path = Path.Combine(Server.MapPath("~/Uploads/images"), fname);
                //path = "/Uploads/images/" + fname;
                //product.ImgaeAvatar = path;
                #endregion
                db.Products.Add(product);
                db.SaveChanges();
                return Json(new
                { data = true }, JsonRequestBehavior.AllowGet);

            }
            ViewBag.Product_Category_TypeId = new SelectList(db.Product_Category_Type.Where(n => n.Status == 1), "Product_Category_TypeId", "Product_Category_TypeName");

            ViewBag.Brand_id = new SelectList(db.Brands.Where(n => n.Status == 1), "Brand_id", "Brand_name");
            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            //set viewBag Product_category_type
            ViewBag.Product_Category_TypeId = new SelectList(db.Product_Category_Type.Where(n => n.Status == 1), "Product_Category_TypeId", "Product_Category_TypeName", product.Product_Category_TypeId);
            //set viewbag brand_id
            ViewBag.Brand_id = new SelectList(db.Brands.Where(n => n.Status == 1), "Brand_id", "Brand_name", product.Brand_id);
            return View("~/Areas/Admin/Views/Products/Edit.cshtml", product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            //set viewBag Product_category_type
            ViewBag.Product_Category_TypeId = new SelectList(db.Product_Category_Type.Where(n => n.Status == 1), "Product_Category_TypeId", "Product_Category_TypeName", product.Product_Category_TypeId);
            //set viewbag brand_id
            ViewBag.Brand_id = new SelectList(db.Brands.Where(n => n.Status == 1), "Brand_id", "Brand_name", product.Brand_id);
            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Products/Delete.cshtml", product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string product_id)
        {
            Product product = db.Products.Find(product_id);
            db.Products.Remove(product);
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
