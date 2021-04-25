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
using LxShop.Commons;

namespace Lx_shop.Areas.Admin.Controllers
{
    public class BrandsController : Controller
    {
        private db_smartphoneEntities db = new db_smartphoneEntities();
        protected readonly IBrandService _BrandService;
        public BrandsController()
        {
            _BrandService = new BrandService();
        }

        // GET: Admin/Brands
        
        public ActionResult Index()
        {
            //return View(db.Brands.ToList());
            return View();
        }
        public PartialViewResult _TableView(Brand model)
        {
            ViewBag.Brand = model;
            IPagedList<Brand> data = _BrandService.PaggingBrand(model);

            return PartialView(data);
        }
        // GET: Admin/Brands/Details/5
      
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Brands/Details.cshtml",brand);
        }

        // GET: Admin/Brands/Create
        public ActionResult Create()
        {
            return View("~/Areas/Admin/Views/Brands/Create.cshtml");
        }

        // POST: Admin/Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                ResponseData<Brand> res = new ResponseData<Brand>();
                bool check = db.Brands.Where(n => n.Brand_name == brand.Brand_name || n.Brand_id == brand.Brand_id).Count() > 0;
                if(check)
                {
                    res.StatusCode = 201;
                    res.ErrorMessage = "Id hoặc tên thương hiệu đã tồn tại ! Vui lòng nhập lại!";
                    return Json(res);
                }
                if(brand.CreateDate == null)
                {
                    brand.CreateDate = DateTime.Now;
                }
                db.Brands.Add(brand);
                db.SaveChanges();
                return Json(new { data = true },JsonRequestBehavior.AllowGet);
            }

            return Json(new { data = false },JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Brands/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Brands/Edit.cshtml",brand);
        }

        // POST: Admin/Brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit( Brand brand)
        {
            if (ModelState.IsValid)
            {

                //ResponseData<Brand> res = new ResponseData<Brand>();
                //bool check = db.Brands.Where(n => n.Brand_name == brand.Brand_name || n.Brand_id == brand.Brand_id).Count() > 0;
                //if (check)
                //{
                //    res.StatusCode = 201;
                //    res.ErrorMessage = "Id hoặc tên thương hiệu đã tồn tại ! Vui lòng nhập lại!";
                //    return Json(res);
                //}
                if (brand.UpdateDate == null)
                {
                    brand.UpdateDate = DateTime.Now;
                }
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = false },JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Brands/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Brands/Delete.cshtml",brand);
        }

        // POST: Admin/Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Brand brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
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
