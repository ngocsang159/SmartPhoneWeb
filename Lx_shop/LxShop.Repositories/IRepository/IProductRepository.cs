using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LxShop.Models.EF;
using PagedList;
namespace LxShop.Repositories
{
    public interface  IProductRepository
    {
        IPagedList<ProductModel> PaggingProduct(ProductModel search1);
        List<ProductModel> LstSpecialProduct();
        List<ProductModel> LstIphoneProduct();
        List<ProductModel> LstSamsungProduct();
        List<ProductModel> LstSmartphone();
        List<AccessorieModel> LstAccessories();
        List<ProductModel> GetProductByBrand_id(string id);
        List<Product> ListProduct(ref int totalRecord, Product model);
        ProductModel GetProductDetail(string id);
        List<ProductModel> LstRelatedProduct(string id);

    }
}
