using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LxShop.Models.EF;
using LxShop.Repositories;
using PagedList;
using LxShop.Commons;

namespace LxShop.Repositories
{
    public class OrderRepository : GenericRepository<OrderModel>, IOrderRepository
    {
        public IPagedList<OrderModel> PaggingOrder(OrderModel search1)
        {
            var query = (from O in db.Orders
                         join OS in db.Order_Status
                         on O.Order_Status_Id equals OS.Order_Status_Id
                         join C in db.Customers
                         on O.Customer_id equals C.Customer_id
                         select new OrderModel()
                         {
                             order = O,
                             order_Status = OS,
                             customer = C
                         });
            return query.WhereIf(!string.IsNullOrEmpty(search1.order_Status.Order_Status_Name), n => n.order_Status.Order_Status_Name.Contains(search1.order_Status.Order_Status_Name)).OrderBy(n => n.order.CreatedDate).ToPagedList(search1.page_num.Value, search1.page_size.Value);
                         

        }
    }
}
