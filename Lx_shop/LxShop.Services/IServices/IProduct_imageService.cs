using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Models.EF;

namespace LxShop.Services
{
     public interface IProduct_imageService
    {
        IPagedList<Product_ImageModel> PaggingProduct_image(Product_ImageModel search);
        List<Product_ImageModel> lstImageProduct(string id);
    }
}
