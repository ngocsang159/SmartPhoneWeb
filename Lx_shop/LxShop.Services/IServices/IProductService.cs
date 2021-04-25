using LxShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace LxShop.Services
{
    public interface IProductService
    {
        IPagedList<ProductModel> PaggingProduct(ProductModel search);
        List<ProductModel> LstSpecialProduct();
        List<ProductModel> LstIphoneProduct();
        List<ProductModel> LstSamsungProduct();
        List<ProductModel> LstSmartPhone();
        List<AccessorieModel> LstAccessories();
        List<ProductModel> GetProductByBrand_id(string id);
        List<Product> ListProduct(ref int totalRecord, Product model);
        ProductModel GetProductDetail(string id);
        List<ProductModel> LstRelatedProduct(string id);




    }
}
