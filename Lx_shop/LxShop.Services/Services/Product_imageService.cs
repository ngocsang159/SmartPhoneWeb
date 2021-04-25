using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Models.EF;

namespace LxShop.Services
{
    public class Product_imageService : GenericService<IProduct_imageService>, IProduct_imageService
    {
      

        public IPagedList<Product_ImageModel> PaggingProduct_image(Product_ImageModel search)
        {
            if (search == null)
            {
                search = new Product_ImageModel();
            }
            if(search.product_Image == null)
            {
                search.product_Image = new Product_image();
                search.product = new Product();
              
            }
            search.page_num = search.page_num ?? 1;
            search.page_size = search.page_size ?? 7;
            return _ProductImageRepository.PaggingProduct_image(search);
        }
        public List<Product_ImageModel> lstImageProduct(string id)
        {
            return _ProductImageRepository.lstImageProduct(id);
        }
    }
}
