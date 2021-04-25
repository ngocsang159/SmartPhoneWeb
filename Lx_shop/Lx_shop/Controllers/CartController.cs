using Lx_shop.Models;
using LxShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LxShop.Services;
using System.Net;

namespace Lx_shop.Controllers
{
    public class CartController : Controller
    {
        protected readonly db_smartphoneEntities db = new db_smartphoneEntities();
        protected readonly IProductService _productService;
        protected readonly IOrderService _orderService;
        private const string CartSession = "CartSession";
        public CartController()
        {
            _productService = new ProductService();
        }
        // GET: Cart
        /// <summary>
        /// Hiển thị giỏ hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewCart()
        {
            var Cart = Session[CartSession];
            List<CartItem> listCart = (List<CartItem>)Cart;
            if(Cart!=null)
            {
                listCart = (List<CartItem>)Cart;
            }
            return View(listCart);
        }


        /// <summary>
        /// Thêm sản phẩm vào giỏ hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(string productId, int quantity)
        {

            var product = _productService.GetProductDetail(productId);
            var cart = Session[CartSession];

            if (cart != null)
            {

                var list = (List<CartItem>)cart;
                //neu list chưa productId truyen vao
                if (list.Exists(n => n.productModel.Product.Product_Id == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.productModel.Product.Product_Id == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //Taoj moi doi tuong
                    CartItem item = new CartItem();
                    item.productModel = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }


            }
            else
            {
                //Taoj moi doi tuong
                CartItem item = new CartItem();
                item.productModel = product;
                item.Quantity = quantity;
                List<CartItem> list = new List<CartItem>();
                list.Add(item);

                //Gán vào session
                Session[CartSession] = list;
            }
            return Json(new { status = true });
        }

        /// <summary>
        /// Cập nhật số lượng  sản phẩm trong giỏ hàng
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateCart(CartItem InfoCartUpdate)
        {
           if(InfoCartUpdate != null)
            {
                var sessionCart = (List<CartItem>)Session[CartSession];
                foreach(var item in sessionCart)
                {
                    if(item.productModel.Product.Product_Id == InfoCartUpdate.productModel.Product.Product_Id)
                    {
                        item.Quantity = InfoCartUpdate.Quantity;
                    }
                    Session[CartSession] = sessionCart;

                }
                List<CartItem> lst = (List<CartItem>)Session[CartSession];
                return Json("OK");
           }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Update fail");
        }

    }
}