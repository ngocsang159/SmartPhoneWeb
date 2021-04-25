using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LxShop.Models.EF;
using LxShop.Services;
using PagedList;

namespace LxShop.Services
{
    public class BannerService : GenericService<BannerModel>, IBannerService
    {
       

        public IPagedList<BannerModel> PaggingBanner(BannerModel search)
        {
            if(search == null)
            {
                search = new BannerModel();
            }
            if(search.banner == null)
            {
                search.banner = new Banner();
                search.product = new Product();
            }
            search.page_num = search.page_num ?? 1;
            search.page_size = search.page_size ?? 7;
            return _BannerRepository.PaggingBanner(search);
        }
        public List<BannerModel> LstBanner()
        {
            return _BannerRepository.LstBanner();
        }
    }
}
