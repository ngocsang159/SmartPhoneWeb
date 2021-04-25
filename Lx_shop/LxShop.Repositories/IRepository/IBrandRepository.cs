using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Models.EF;
namespace LxShop.Repositories
{
    public interface IBrandRepository
    {
        IPagedList<Brand> PaggingBrand(Brand search1);
        List<Brand> ListBrands();
    }
}
