using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using LxShop.Models.EF;
using LxShop.Commons;


namespace LxShop.Services
{
    public interface ICustomerService
    {
        IPagedList<CustomerModel> PaggingCustomer(CustomerModel search);
        ResponseData<Customer> CheckLogin(Customer model);
        ResponseData<Customer> CheckRegister(Customer model);
    }
}
