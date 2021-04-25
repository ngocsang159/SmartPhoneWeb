using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LxShop.Commons;
using LxShop.Services;

using LxShop.Models.EF;
using System.Web.Security;

namespace Lx_shop.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IProduct_Category_TypeService product_Category_TypeService;
        protected readonly IBrandService brandService;
        protected readonly IBannerService bannerService;
        protected readonly IProductService productService;
        protected readonly IProduct_imageService product_ImageService;
        protected readonly IProduct_SpecificationService product_SpecificationService;
        public HomeController()
        {
            product_Category_TypeService = new Product_Category_TypeService();
            brandService = new BrandService();
            bannerService = new BannerService();
            productService = new ProductService();
            product_ImageService = new Product_imageService();
            product_SpecificationService = new Product_SpecificationService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogoutClient()
        {
            Session["CUSTOMER"] = null;
            return Redirect("/");
        }
        /// <summary>
        /// Login: đăng nhập tài khoản khách hàng
        /// </summary>
        /// <returns></returns>
        public PartialViewResult Header_Top_Right()
        {
            Customer model = Session["CUSTOMER"] as Customer;
            return PartialView("~/Views/Home/Header_Top_Right.cshtml", model);
        }
      
        public PartialViewResult _ProductCategory()
        {
            ViewBag.ProductCategory_Type = product_Category_TypeService.lstProduct_Category_Type();
            ViewBag.Brand = brandService.GetBrands();
            return PartialView();
        }
        public PartialViewResult _SlideBanner()
        {
            ViewBag.BannerModel = bannerService.LstBanner();
            return PartialView();
        }
        public PartialViewResult _BannerAdvertisement()
        {
            ViewBag.BannerModel = bannerService.LstBanner();
            return PartialView();
        }
        public PartialViewResult _BannerAccessories()
        {
            ViewBag.BannerModel = bannerService.LstBanner();
            return PartialView();
        }
        public PartialViewResult _ListSpecialProduct()
        {
            ViewBag.ProductModel = productService.LstSpecialProduct();
            return PartialView();
        }
        public PartialViewResult _ListIphoneProduct()
        {
            List<ProductModel> lst_Iphone = productService.LstIphoneProduct();
            return PartialView(lst_Iphone);
        }
        public PartialViewResult _ListSamsungProduct()
        {
            List<ProductModel> lst_Samsung = productService.LstSamsungProduct();
                return PartialView(lst_Samsung);
        }
        public PartialViewResult _ListSmartphone()
        {
            List<ProductModel> lstSmartphone = productService.LstSmartPhone();
            return PartialView(lstSmartphone);
        }
        public PartialViewResult _ListAccessories()
        {
            List<AccessorieModel> lstAccessories = productService.LstAccessories();
            return PartialView(lstAccessories);
        }
        /// <summary>
        /// Lấy sản phẩm theo tên hãng sản xuất
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetProductByBrand(Product model)
        {
            ViewBag.ProductModel = productService.GetProductByBrand_id(model.Brand_id);
            int totalRecord = 0;
            List<Product> get_Product = productService.ListProduct(ref totalRecord, model);
            ViewBag.Total = totalRecord;
            ViewBag.Page = model.page_num;
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling(((Double)totalRecord / (Double)model.page_size));
            ViewBag.TotalPage = totalPage;
            ViewBag.Maxpage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = model.page_num + 1;
            ViewBag.Prev = model.page_num - 1;
            return View(get_Product);

    
        }
        public ActionResult ViewProductDetail(string id)
        {
            ViewBag.DetailProduct = productService.GetProductDetail(id);
            ViewBag.ProductModel = productService.GetProductByBrand_id(id);
            ViewBag.ProductImage = product_ImageService.lstImageProduct(id);
            ViewBag.ProductSpecification = product_SpecificationService.LstSpecificationByProduct_Id(id);
            List<ProductModel> lstRelatedProduct = productService.LstRelatedProduct(id);
           
            return View(lstRelatedProduct);
        }



    }
}