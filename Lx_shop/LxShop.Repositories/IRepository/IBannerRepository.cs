using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LxShop.Models.EF;
using LxShop.Repositories;
using PagedList;

namespace LxShop.Repositories
{
    public interface IBannerRepository
    {
        IPagedList<BannerModel> PaggingBanner(BannerModel search1);
        List<BannerModel> LstBanner();
    }
}
