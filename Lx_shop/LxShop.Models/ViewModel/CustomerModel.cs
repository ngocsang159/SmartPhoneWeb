using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxShop.Models.EF
{
    public class CustomerModel
    {
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        public Customer customer { get; set; }
        public Province province { get; set; }
        public District district { get; set; }
    }
}
