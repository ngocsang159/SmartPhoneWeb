using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Models.EF;
using LxShop.Commons;

namespace LxShop.Repositories
{
    public class Product_SpecificationRepository : GenericRepository<Product_SpecificationModel>, IProduct_SpecificationRepository
    {
       

        public IPagedList<Product_SpecificationModel> PaggingProduct_Specification(Product_SpecificationModel search1)
        {
            var query = (from P in db.Products
                         join PS in db.Product_Specifications
                         on P.Product_Id equals PS.Product_Id
                         select new Product_SpecificationModel()
                         {
                             _product = P,
                             product_Specifications = PS
                         }) ;
            return query.WhereIf(!string.IsNullOrEmpty(search1._product.Product_Name), n => n._product.Product_Name.Contains(search1._product.Product_Name)).OrderBy(n => n._product.CreateDate).ToPagedList(search1.page_num.Value, search1.page_size.Value);
        }
        public List<Product_SpecificationModel> LstSpecificationByProduct_Id(string id)
        {
            var data = (from P in db.Products
                         join PS in db.Product_Specifications
                         on P.Product_Id equals PS.Product_Id
                         
                         select new Product_SpecificationModel()
                         {
                             _product = P,
                             product_Specifications = PS
                         }).ToList();
            return data.Where(n => n._product.Product_Id == id && n.product_Specifications.Status ==1).ToList();
        }
    }
}
