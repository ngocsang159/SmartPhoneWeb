using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Models.EF;

namespace LxShop.Services
{
    public class Product_SpecificationService : GenericService<Product_SpecificationModel>, IProduct_SpecificationService
    {
       

        public IPagedList<Product_SpecificationModel> PaggingProduct_Specification(Product_SpecificationModel search)
        {
            if (search == null)
            {
                search = new Product_SpecificationModel();
            }
            if(search.product_Specifications == null)
            {
                search.product_Specifications = new Product_Specifications();
                search._product = new Product();
            }
            search.page_num = search.page_num ?? 1;
            search.page_size = search.page_size ?? 7;
            return _ProductSpecificationRepository.PaggingProduct_Specification(search);
        }

        public List<Product_SpecificationModel> LstSpecificationByProduct_Id(string id)
        {
            return _ProductSpecificationRepository.LstSpecificationByProduct_Id(id);
        }
    }
}
