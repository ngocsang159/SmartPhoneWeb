using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Models.EF;

namespace LxShop.Services
{
    public interface  IProduct_ColorService
    {
        IPagedList<Product_ColorModel> PaggingProduct_Color(Product_ColorModel search);
    }
}
