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
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public List<Brand> ListBrands()
        {
            return db.Brands.ToList();
        }

        public IPagedList<Brand> PaggingBrand(Brand search1)
        {
            return db.Brands.AsQueryable()
               .WhereIf(!string.IsNullOrEmpty(search1.Brand_name), n => n.Brand_name.ToLower().Contains(search1.Brand_name)).OrderBy(n => n.Brand_name).ToPagedList(search1.page_num.Value, search1.page_size.Value);
        }
    }
}
