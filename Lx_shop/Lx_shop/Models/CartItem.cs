using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LxShop.Models.EF;

namespace Lx_shop.Models
{
    [Serializable]
    public class CartItem
    {
        public ProductModel productModel { get; set; }
        public int Quantity { get; set; }
    }
}