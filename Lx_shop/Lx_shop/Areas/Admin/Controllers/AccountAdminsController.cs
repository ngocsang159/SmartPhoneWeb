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
using System.IO;
using System.Configuration;

namespace Lx_shop.Areas.Admin.Controllers
{
    public class AccountAdminsController : Controller
    {
        private db_smartphoneEntities db = new db_smartphoneEntities();
        private readonly IAccountAdminService _service;
        public AccountAdminsController()
        {
            _service = new AccountAdminService();
        }
        // GET: Admin/AccountAdmins
        public ActionResult Index()
        {
            return View();
            //return View(db.AccountAdmins.ToList());
        }

        public PartialViewResult _TableView(AccountAdmin model)
        {
            ViewBag.AccountAdmin = model;
            IPagedList<AccountAdmin> data = _service.PaggingAjax(model);
            return PartialView(data);
        }
        // GET: Admin/AccountAdmins/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountAdmin accountAdmin = db.AccountAdmins.Find(id);
            if (accountAdmin == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/AccountAdmins/Details.cshtml", accountAdmin);
        }

        // GET: Admin/AccountAdmins/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Admin/AccountAdmins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stt,ID,Username,Password,Avatar,Gender,Displayname,Phone,Facebook,Email,Address,Status,CreateDate,CreateBy,UpdatedDate,UpdatedBy,IsDeleted")] AccountAdmin accountAdmin)
        {
            if (ModelState.IsValid)
            {
                db.AccountAdmins.Add(accountAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountAdmin);
        }

        // GET: Admin/AccountAdmins/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountAdmin accountAdmin = db.AccountAdmins.Find(id);
            if (accountAdmin == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/AccountAdmins/Edit.cshtml", accountAdmin);
        }

        // POST: Admin/AccountAdmins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(AccountAdmin accountAdmin)
        {
            if (ModelState.IsValid)
            {

                var obj = db.AccountAdmins.Find(accountAdmin.ID);
                obj.Username = accountAdmin.Username;
                obj.Gender = accountAdmin.Gender;
                obj.Displayname = accountAdmin.Displayname;
                obj.Phone = accountAdmin.Phone;
                obj.Email = accountAdmin.Email;
                obj.Address = accountAdmin.Address;
                obj.Status = accountAdmin.Status;
                obj.CreateDate = accountAdmin.CreateDate;
                obj.CreateBy = accountAdmin.CreateBy;
                obj.UpdatedDate = accountAdmin.UpdatedDate;
                obj.UpdatedBy = accountAdmin.UpdatedBy;
                
                // ....

                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);


            }
            return Json(new { data = false }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/AccountAdmins/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountAdmin accountAdmin = db.AccountAdmins.Find(id);
            if (accountAdmin == null)
            {
                return HttpNotFound();
            }
            return View("~/Areas/Admin/Views/AccountAdmins/Delete.cshtml", accountAdmin);
        }

        // POST: Admin/AccountAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            AccountAdmin accountAdmin = db.AccountAdmins.Find(id);
            db.AccountAdmins.Remove(accountAdmin);
            db.SaveChanges();
            return Json(new { data = true }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Lấy tên người dùng hiện thị menu top-left
        /// 
        /// </summary>
        /// <param name=""></param>
        /// 
      
        public PartialViewResult UserPanel()
        {
            AccountAdmin model = Session["USER"] as AccountAdmin;
            return PartialView("~/Areas/Admin/Views/AccountAdmins/UserPanel.cshtml", model);
        }
        /// <summary>
        /// Hiển thị thông tin người dùng menu top-right
        /// </summary>
        /// <returns></returns>
        public PartialViewResult UserMenu()
        {
            AccountAdmin model = Session["USER"] as AccountAdmin;
            return PartialView("~/Areas/Admin/Views/AccountAdmins/UserMenu.cshtml", model);
        }
        [HttpPost]
        public ActionResult UploadImage()
        {
            AccountAdmin model = Session["USER"] as AccountAdmin;
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    HttpPostedFileBase file = files[0];
                    string fname;

                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = DateTime.Now.ToString("yyyyMMddhhmmss") + file.FileName ;
                    }

                    // Get the complete folder path and store the file inside it.  
                    var path = Path.Combine(Server.MapPath("~/Uploads/images"), fname);
                    file.SaveAs(path);
                    path = "/Uploads/images/" + fname;
                    // Returns message that successfully uploaded  
                    var user = db.AccountAdmins.Find(model.ID);
                    if (user != null)
                    {
                        user.Avatar = path;
                        Session["USER"] = user;
                        db.SaveChanges();  
                    }
                    return Json(path);
                }
                catch (Exception ex)
                {
                    return Json("");
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        //upload file
       
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
