using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxShop.Models.EF
{
    public class BannerModel
    {
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        public Banner banner { get; set; }
        public Product product { get; set; }
    }
}
