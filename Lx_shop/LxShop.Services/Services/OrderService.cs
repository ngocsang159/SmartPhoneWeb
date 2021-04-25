using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LxShop.Models.EF;
using LxShop.Services;
using LxShop.Repositories;
using PagedList;

namespace LxShop.Services
{
    public class OrderService : GenericService<OrderModel>, IOrderService
    {
        public IPagedList<OrderModel> PaggingOrder(OrderModel search)
        {
            if(search == null)
            {
                search = new OrderModel();
            }
            if(search.order == null)
            {
                search.order = new Order();
                search.order_Status = new Order_Status();
                search.customer = new Customer();
            }
            search.page_num = search.page_num ?? 1;
            search.page_size = search.page_size ?? 7;
            return _OrderRepository.PaggingOrder(search);
        }
    }
}
