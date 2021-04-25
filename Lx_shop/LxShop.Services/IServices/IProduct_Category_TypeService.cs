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
    public interface IProduct_Category_TypeService
    {
        IPagedList<ProductCategory_Type> PaggingCategoryType(ProductCategory_Type search);
        List<ProductCategory_Type> lstProduct_Category_Type();    
    }
    
}
