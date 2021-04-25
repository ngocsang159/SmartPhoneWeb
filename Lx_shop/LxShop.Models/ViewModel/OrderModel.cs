using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxShop.Models.EF
{
   public class OrderModel
    {
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        public Order order { get; set; }
        public Order_Status order_Status { get; set; }
        public Customer customer { get; set; }
    }
}
