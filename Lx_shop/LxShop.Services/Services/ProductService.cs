using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Commons;
using LxShop.Models.EF;

namespace LxShop.Services
{
    public class ProductService : GenericService<
        ProductModel>, IProductService
    {

        public IPagedList<ProductModel> PaggingProduct(ProductModel search)
        {
            if (search == null)
            {
                search = new ProductModel();
            }
            if (search.Product == null)
            {
                search.Product = new Product();
                //search.Product_Category_Type = new Product_Category_Type();
                //search.Brand = new Brand();

            }
            search.page_num = search.page_num ?? 1;
            search.page_size = search.page_size ?? 7;
            return _ProductRepository.PaggingProduct(search);
        }
        public List<ProductModel> LstSpecialProduct()
        {
            return _ProductRepository.LstSpecialProduct();
        }
        public List<ProductModel> LstIphoneProduct()
        {
            return _ProductRepository.LstIphoneProduct();
        }
        public List<ProductModel> LstSamsungProduct()
        {
            return _ProductRepository.LstSamsungProduct();
        }
        public List<ProductModel> LstSmartPhone()
        {
            return _ProductRepository.LstSmartphone();
        }
        public List<AccessorieModel> LstAccessories()
        {
            return _ProductRepository.LstAccessories();
        }
        public List<ProductModel> GetProductByBrand_id(string id)
        {
            return _ProductRepository.GetProductByBrand_id(id);
        }

        public List<Product> ListProduct(ref int totalRecord, Product model)
        {
            if (model == null)
            {
                model = new Product();
            }
            
            model.page_num = model.page_num ?? 1;
            model.page_size = model.page_size ?? 9;
            return _ProductRepository.ListProduct(ref totalRecord, model);
        }

        public ProductModel GetProductDetail(string id)
        {
            return _ProductRepository.GetProductDetail(id);
        }

        public List<ProductModel> LstRelatedProduct(string id)
        {
            return _ProductRepository.LstRelatedProduct(id);
        }

        
    }
}
