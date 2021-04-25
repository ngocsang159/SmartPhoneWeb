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
    public class BannersController : Controller
    {
        private db_smartphoneEntities db = new db_smartphoneEntities();
        protected readonly IBannerService _bannerService;
        public BannersController()
        {
            _bannerService = new BannerService();
        }

        // GET: Admin/Banners
        public ActionResult Index()
        {
            //return View(db.Banners.ToList());
            return View();
        }
        public PartialViewResult _TableView(BannerModel model)
        {
            ViewBag.BannerModel  = model;
            IPagedList<BannerModel> data = _bannerService.PaggingBanner(model);
            return PartialView(data);
        }

        // GET: Admin/Banners/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = (from BN in db.Banners
                         join P in db.Products
                         on BN.Product_Id equals P.Product_Id
                         select new BannerModel()
                         {
                             banner = BN,
                             product = P
                         });
            BannerModel banner = query.Where(n => n.banner.Banner_Id == id).FirstOrDefault();
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Banners/Details.cshtml", banner);
        }

        // GET: Admin/Banners/Create
        public ActionResult Create()
        {
            ViewBag.Product_Id = new SelectList(db.Products.Where(n => n.Status == 1), "Product_Id", "Product_Name");
            return View("~/Areas/Admin/Views/Banners/Create.cshtml");
        }

        // POST: Admin/Banners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create( Banner banner)
        {
            if (ModelState.IsValid)
            {
                db.Banners.Add(banner);
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            ViewBag.Product_Id = new SelectList(db.Products.Where(n => n.Status == 1), "Product_Id", "Product_Name",banner.Product_Id);
            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Banners/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_Id = new SelectList(db.Products.Where(n => n.Status == 1), "Product_Id", "Product_Name",banner.Product_Id);
            return View("~/Areas/Admin/Views/Banners/Edit.cshtml",banner);
        }

        // POST: Admin/Banners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit( Banner banner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banner).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            ViewBag.Product_Id = new SelectList(db.Products.Where(n => n.Status == 1), "Product_Id", "Product_Name",banner.Product_Id);
            return Json(new { data = true }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Banners/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/Banners/Delete.cshtml",banner);
        }

        // POST: Admin/Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Banner banner = db.Banners.Find(id);
            db.Banners.Remove(banner);
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
