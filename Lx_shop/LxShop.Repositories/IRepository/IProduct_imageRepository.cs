using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Models.EF;

namespace LxShop.Repositories
{
    public interface IProduct_imageRepository
    {
        IPagedList<Product_ImageModel> PaggingProduct_image(Product_ImageModel search1);
        List<Product_ImageModel> lstImageProduct(string id);
    }
}
