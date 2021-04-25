using LxShop.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LxShop.Commons;

namespace LxShop.Repositories
{
    public class BannerRepository : GenericRepository<BannerModel>, IBannerRepository
    {
       
        public IPagedList<BannerModel> PaggingBanner(BannerModel search1)
        {
            var query = (from BN in db.Banners
                         join P in db.Products
                         on BN.Product_Id equals P.Product_Id
                         select new BannerModel()
                         {
                             banner = BN,
                             product = P
                         });
            return query.WhereIf(!string.IsNullOrEmpty(search1.product.Product_Name), n => n.product.Product_Name.Contains(search1.product.Product_Name))
               .WhereIf(!string.IsNullOrEmpty(search1.banner.Banner_Name), n => n.banner.Banner_Name.Contains(search1.banner.Banner_Name))
               .OrderBy(n => n.banner.CreatedDate).ToPagedList(search1.page_num.Value, search1.page_size.Value);
        }
        public List<BannerModel> LstBanner()
        {
            List<BannerModel> lstbanner = (from BN in db.Banners
                              join P in db.Products
                              on BN.Product_Id equals P.Product_Id
                              select new BannerModel()
                              {
                                  banner = BN,
                                  product = P
                              }).ToList();
            return lstbanner;
            
        }

    }
}
