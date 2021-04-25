using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Models.EF;
using LxShop.Commons;
using LxShop.Repositories;

namespace LxShop.Repositories
{
    public interface ICustomerRepository
    {
        IPagedList<CustomerModel> PaggingCustomer(CustomerModel search1);
        ResponseData<Customer> CheckLoginClient(Customer model);
        ResponseData<Customer> CheckRegisterClient(Customer model);
    }
}
