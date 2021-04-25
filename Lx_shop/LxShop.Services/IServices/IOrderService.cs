﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LxShop.Models.EF;
using PagedList;

namespace LxShop.Services
{
    public interface IOrderService
    {
        IPagedList<OrderModel> PaggingOrder(OrderModel search);
    }
}
