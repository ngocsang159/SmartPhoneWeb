using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Models.EF;
using LxShop.Commons;

namespace LxShop.Services
{

    public class Product_Category_TypeService : GenericService<ProductCategory_Type>, IProduct_Category_TypeService
    {
       

        public IPagedList<ProductCategory_Type> PaggingCategoryType(ProductCategory_Type search)
        {
            if(search == null)
            {
                search = new ProductCategory_Type();
            }
            if (search.Product_Category_Type == null)
            {
                search.Product_Category_Type = new Product_Category_Type();
                search.Product_Category = new Product_Category();
                
            }
            search.page_num = search.page_num ?? 1;
            search.page_size = search.page_size ?? 7;
            return _ProductCategoryTypeRepository.PaggingCategoryType(search);
        }
        public List<ProductCategory_Type> lstProduct_Category_Type()
        {
            return _ProductCategoryTypeRepository.lstproductCategory_Types();
        }
    }
}
