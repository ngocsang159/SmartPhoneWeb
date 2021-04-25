using LxShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LxShop.Services;

namespace Lx_shop.Controllers
{
    public class MainMenuController : Controller
    {
        private db_smartphoneEntities db = new db_smartphoneEntities();
        protected IProduct_categoryService _product_CategoryService;
        protected IProduct_Category_TypeService _Category_TypeService;
        protected IBrandService _brandService;
        public MainMenuController()
        {
            _product_CategoryService = new Product_CategoryService();
            _Category_TypeService = new Product_Category_TypeService();
            _brandService = new BrandService();
        }
        // GET: MainMenu
        public PartialViewResult MainMenu()
        {
            ViewBag.Product_Category = _product_CategoryService.ListProduct_Category();
            ViewBag.ProductCategory_Type = _Category_TypeService.lstProduct_Category_Type();
            ViewBag.Brand = _brandService.GetBrands();
            return PartialView();
        }
    }
}