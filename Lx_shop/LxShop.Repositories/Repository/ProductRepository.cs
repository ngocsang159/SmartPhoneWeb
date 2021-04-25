using LxShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Commons;
namespace LxShop.Repositories
{
    public class ProductRepository : GenericRepository<ProductModel>, IProductRepository
    {

        public IPagedList<ProductModel> PaggingProduct(ProductModel search1)
        {
            var query = (from P in db.Products
                         join PCT in db.Product_Category_Type
                         on P.Product_Category_TypeId equals PCT.Product_Category_TypeId
                         join B in db.Brands
                         on P.Brand_id equals B.Brand_id
                         select new ProductModel()
                         {
                             Product = P,
                             Product_Category_Type = PCT,
                             Brand = B
                         });

            return query.WhereIf(!string.IsNullOrEmpty(search1.Product.Product_Name), n => n.Product.Product_Name.Contains(search1.Product.Product_Name)).OrderBy(n => n.Product.Product_Name).ToPagedList(search1.page_num.Value, search1.page_size.Value);

        }
        public List<ProductModel> LstSpecialProduct()
        {
            var query = (from P in db.Products
                         join PCT in db.Product_Category_Type
                         on P.Product_Category_TypeId equals PCT.Product_Category_TypeId
                         join B in db.Brands
                         on P.Brand_id equals B.Brand_id
                         select new ProductModel()
                         {
                             Product = P,
                             Product_Category_Type = PCT,
                             Brand = B
                         });
            return query.Where(n => n.Product.Is_Hot == 1 && n.Product.Status == 1).OrderBy(n => n.Product.CreateDate).ToList();
        }

        public List<ProductModel> LstIphoneProduct()
        {
            List<ProductModel> data = (from P in db.Products
                                       join PCT in db.Product_Category_Type
                                       on P.Product_Category_TypeId equals PCT.Product_Category_TypeId
                                       join B in db.Brands
                                       on P.Brand_id equals B.Brand_id
                                       where P.Product_Name.StartsWith("Apple") && P.Status == 1 && P.Old_New == 1
                                       select new ProductModel()
                                       {
                                           Product = P,
                                           Product_Category_Type = PCT,
                                           Brand = B
                                       }).ToList();
            return data;
        }

        public List<ProductModel> LstSamsungProduct()
        {
            List<ProductModel> data = (from P in db.Products
                                       join PCT in db.Product_Category_Type
                                       on P.Product_Category_TypeId equals PCT.Product_Category_TypeId
                                       join B in db.Brands
                                       on P.Brand_id equals B.Brand_id
                                       where P.Product_Name.StartsWith("Samsung") && P.Status == 1 && P.Old_New == 1 && PCT.Product_Category_TypeName == "Điện Thoại"
                                       select new ProductModel()
                                       {
                                           Product = P,
                                           Product_Category_Type = PCT,
                                           Brand = B
                                       }).ToList();
            return data;
        }
        public List<ProductModel> LstSmartphone()
        {

            List<ProductModel> data = (from P in db.Products
                                       join PCT in db.Product_Category_Type
                                       on P.Product_Category_TypeId equals PCT.Product_Category_TypeId
                                       join B in db.Brands
                                       on P.Brand_id equals B.Brand_id
                                       where !P.Product_Name.StartsWith("Samsung") && P.Status == 1 && P.Old_New == 1 && PCT.Product_Category_TypeName == "Điện Thoại"
                                       select new ProductModel()
                                       {
                                           Product = P,
                                           Product_Category_Type = PCT,
                                           Brand = B
                                       }).ToList();
            return data;

        }
        public List<AccessorieModel> LstAccessories()
        {
            List<AccessorieModel> data = (from P in db.Products
                                       join PCT in db.Product_Category_Type
                                       on P.Product_Category_TypeId equals PCT.Product_Category_TypeId
                                       join PC in db.Product_Category
                                       on PCT.Product_CategoryId equals PC.Product_CategoryId
                                       join B in db.Brands
                                       on P.Brand_id equals B.Brand_id
                                       where P.Status == 1 && P.Old_New == 1 && PC.Product_CategoryName == "Phụ Kiện"
                                       select new AccessorieModel()
                                       {
                                           Product = P,
                                          Product_Category_Type = PCT,
                                          product_Category = PC,
                                           Brand = B

                                       }).ToList();
            return data;
        }
        public List<ProductModel> GetProductByBrand_id(string id)
        {
            List<ProductModel> data = (from P in db.Products
                                       join PCT in db.Product_Category_Type
                                       on P.Product_Category_TypeId equals PCT.Product_Category_TypeId
                                       join B in db.Brands
                                       on P.Brand_id equals B.Brand_id
                                       where B.Brand_id == id || P.Product_Id == id && P.Status == 1
                                       select new ProductModel()
                                       {
                                           Product = P,
                                           Product_Category_Type = PCT,
                                           Brand = B
                                       }).ToList();
            return data;
        }

        public List<Product> ListProduct(ref int totalRecord, Product model)
        {
            int page_num = (int)model.page_num;
            int page_size = (int)model.page_size;
            //var query = (from P in db.Products
            //             join PCT in db.Product_Category_Type
            //             on P.Product_Category_TypeId equals PCT.Product_Category_TypeId
            //             join B in db.Brands
            //             on P.Brand_id equals B.Brand_id
            //             select new ProductModel()
            //             {
            //                 Product = P,
            //                 Product_Category_Type = PCT,
            //                 Brand = B
            //             });
            totalRecord = db.Products.Where(n => n.Brand_id == model.Brand_id && n.Status == 1).Count();
            var data = db.Products.Where(n => n.Brand_id == model.Brand_id && n.Status == 1).OrderBy(n => n.CreateDate).Skip((page_num - 1) * page_size).Take(page_size).ToList();
            return data;
        }

        public ProductModel GetProductDetail(string id)
        {
            var data = (from P in db.Products
                        join PCT in db.Product_Category_Type
                        on P.Product_Category_TypeId equals PCT.Product_Category_TypeId
                        join B in db.Brands
                        on P.Brand_id equals B.Brand_id
                        select new ProductModel()
                        {
                            Product = P,
                            Product_Category_Type = PCT,
                            Brand = B
                        }).ToList();
            return data.Where(n => n.Product.Product_Id == id || n.Product.Brand_id == id).FirstOrDefault();
        }

        public List<ProductModel> LstRelatedProduct(string id)
        {
            var data = (from P in db.Products
                        join PCT in db.Product_Category_Type
                        on P.Product_Category_TypeId equals PCT.Product_Category_TypeId
                        join B in db.Brands
                        on P.Brand_id equals B.Brand_id
                        select new ProductModel()
                        {
                            Product = P,
                            Product_Category_Type = PCT,
                            Brand = B
                        }).ToList();
            ProductModel getById = data.Where(n => n.Product.Product_Id == id || n.Product.Brand_id == id).FirstOrDefault();
            return data.Where(n => n.Product.Brand_id == getById.Product.Brand_id).ToList();
        }


    }
}
