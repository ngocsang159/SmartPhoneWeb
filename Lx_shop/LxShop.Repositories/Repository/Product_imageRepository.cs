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
    public class Product_imageRepository : GenericRepository<Product_ImageModel>, IProduct_imageRepository
    {
       

        public IPagedList<Product_ImageModel> PaggingProduct_image(Product_ImageModel search1)
        {
            var query = (from PI in db.Product_image
                         join P in db.Products
                         on PI.Product_Id equals P.Product_Id
                    
                         select new Product_ImageModel()
                         {
                             product_Image = PI,
                             product = P,
                  
                         });
            return query
               .WhereIf(!string.IsNullOrEmpty(search1.product.Product_Name), n => n.product.Product_Name.Contains(search1.product.Product_Name))
               .WhereIf(!string.IsNullOrEmpty(search1.product_Image.Image_Id), n => n.product_Image.Image_Id.Contains(search1.product_Image.Image_Id))
               .OrderBy(n => n.product_Image.CreateDate).ToPagedList(search1.page_num.Value, search1.page_size.Value);
        }
        public List<Product_ImageModel> lstImageProduct(string id)
        {
            List<Product_ImageModel> data= (from PI in db.Product_image
                         join P in db.Products
                         on PI.Product_Id equals P.Product_Id
                         where P.Product_Id == id && PI.Status == 1
                         select new Product_ImageModel()
                         {
                             product_Image = PI,
                             product = P,

                         }).ToList();
            return data;
        }
    }
}
