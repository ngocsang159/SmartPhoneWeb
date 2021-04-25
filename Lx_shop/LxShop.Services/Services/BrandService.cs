using LxShop.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxShop.Services
{
    public class BrandService : GenericService<Brand>, IBrandService
    {
        public List<Brand> GetBrands()
        {
            return _BrandRepository.ListBrands();
        }

        public IPagedList<Brand> PaggingBrand(Brand search)
        {
            if(search == null)
            {
                search = new Brand();
            }
            search.page_num = search.page_num ?? 1;
            search.page_size = search.page_size ?? 7;
            return _BrandRepository.PaggingBrand(search);
        }
    }
}
