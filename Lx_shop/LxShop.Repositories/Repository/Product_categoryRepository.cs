using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LxShop.Commons;
using LxShop.Models.EF;
using PagedList;

namespace LxShop.Repositories
{
    public class Product_categoryRepository : GenericRepository<Product_Category>,IProduct_categoryRepository
    {
        

        public IPagedList<Product_Category> PaggingProduct_category(Product_Category search1)
        {
            return db.Product_Category.AsQueryable()
                .WhereIf(!string.IsNullOrEmpty(search1.Product_CategoryName), n => n.Product_CategoryName.Contains(search1.Product_CategoryName)).OrderBy(n => n.Product_CategoryName).ToPagedList(search1.page_num.Value, search1.page_size.Value);
        }
        public List<Product_Category> ListProduct_Category()
        {
            return db.Product_Category.ToList();
        }
    }
}
