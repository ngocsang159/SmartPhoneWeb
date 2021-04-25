using LxShop.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LxShop.Commons;

namespace LxShop.Services
{
    public class Product_CategoryService : GenericService<Product_Category>, IProduct_categoryService
    {
       

        public IPagedList<Product_Category> PaggingProduct_category(Product_Category search)
        {
            if (search == null)
            {
                search = new Product_Category();
            }
            search.page_num = search.page_num ?? 1;
            search.page_size = search.page_size ?? 7;
            return _ProductCategoryRepository.PaggingProduct_category(search);

        }
        public List<Product_Category> ListProduct_Category()
        {
            return _ProductCategoryRepository.ListProduct_Category();
        }


    }  
}
