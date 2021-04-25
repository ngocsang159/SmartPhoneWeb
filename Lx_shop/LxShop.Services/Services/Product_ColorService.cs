using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Models.EF;

namespace LxShop.Services
{
    public class Product_ColorService : GenericService<Product_ColorModel>, IProduct_ColorService
    {
        public IPagedList<Product_ColorModel> PaggingProduct_Color(Product_ColorModel search)
        {
            if (search == null)
            {
                search = new Product_ColorModel();
            }
            if(search.product_color == null)
            {
                search.product_color = new Product_Color();
                search.product = new Product();
            }
            search.page_num = search.page_num ?? 1;
            search.page_size = search.page_size ?? 7;
            return _ProductColorRepository.PaggingProduct_Color(search);
        }
    }
}
