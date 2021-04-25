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
    public class Product_ColorRepository : GenericRepository<Product_ColorModel>, IProduct_ColorRepository
    {
        public IPagedList<Product_ColorModel> PaggingProduct_Color(Product_ColorModel search1)
        {
            var query = (from PC in db.Product_Color
                         join P in db.Products
                         on PC.Product_Id equals P.Product_Id
                         select new Product_ColorModel()
                         {
                             product = P,
                             product_color = PC
                         });
            return query.WhereIf(!string.IsNullOrEmpty(search1.product_color.Color_name), n => n.product_color.Color_name.Contains(search1.product_color.Color_name))
                .OrderBy(n => n.product_color.Color_Id).ToPagedList(search1.page_num.Value, search1.page_size.Value);
        }
    }
}
