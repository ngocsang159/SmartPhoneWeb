using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Commons;
using LxShop.Models.EF;
using System.Data.Entity;


namespace LxShop.Repositories
{
    public class Product_Category_TypeRepository : GenericRepository<Product_Category_Type>, IProduct_Category_TypeRepository
    {
       

        public IPagedList<ProductCategory_Type> PaggingCategoryType(ProductCategory_Type search1)
        {
            var query = (from PC in db.Product_Category
                         join PCT in db.Product_Category_Type
                         on PC.Product_CategoryId equals PCT.Product_CategoryId
                         select new ProductCategory_Type() { 
                             Product_Category = PC, 
                             Product_Category_Type = PCT });//

            return query.
                 WhereIf(!string.IsNullOrEmpty(search1.Product_Category_Type.Product_Category_TypeName), n => n.Product_Category_Type.Product_Category_TypeName.Contains(search1.Product_Category_Type.Product_Category_TypeName)).OrderBy(n =>n.Product_Category_Type.CreatedDate).ToPagedList(search1.page_num.Value,search1.page_size.Value);
        }
        public List<ProductCategory_Type> lstproductCategory_Types()
        {
            List<ProductCategory_Type>  query = (from PC in db.Product_Category
                         join PCT in db.Product_Category_Type
                         on PC.Product_CategoryId equals PCT.Product_CategoryId
                         
                         select new ProductCategory_Type() { Product_Category = PC, Product_Category_Type = PCT }).ToList();//
            return query;
        }
    }
}
