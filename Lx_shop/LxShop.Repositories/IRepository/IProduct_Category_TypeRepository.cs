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
   public interface  IProduct_Category_TypeRepository
    {
        IPagedList<ProductCategory_Type> PaggingCategoryType(ProductCategory_Type search1);
        List<ProductCategory_Type> lstproductCategory_Types();
    }
}
