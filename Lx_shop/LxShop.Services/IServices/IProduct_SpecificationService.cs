using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Models.EF;

namespace LxShop.Services
{
    public interface IProduct_SpecificationService
    {
        IPagedList<Product_SpecificationModel> PaggingProduct_Specification(Product_SpecificationModel search);
        List<Product_SpecificationModel> LstSpecificationByProduct_Id(string id);
    }
}
