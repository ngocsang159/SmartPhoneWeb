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
    public class CustomerService : GenericService<CustomerModel>, ICustomerService
    {
      

        public IPagedList<CustomerModel> PaggingCustomer(CustomerModel search)
        {
           if(search == null)
            {
                search = new CustomerModel();
            }
           if(search.customer == null)
            {
                search.customer = new Customer();
                search.province = new Province();
                search.district = new District();
            }
            search.page_num = search.page_num ?? 1;
            search.page_size = search.page_size ?? 7;
            return _CustomerRepository.PaggingCustomer(search);
        }
        public ResponseData<Customer> CheckLogin(Customer model)
        {
            ResponseData<Customer> res = new ResponseData<Customer>();
            if(string.IsNullOrEmpty(model.email)||string.IsNullOrEmpty(model.Password))
            {
                res.StatusCode = 201;
                res.ErrorMessage = "Đăng nhập không thành công!";
                return res;
            }
            res = _CustomerRepository.CheckLoginClient(model);
            if(res.Data == null)
            {
                res.StatusCode = 201;
                res.ErrorMessage = "Tài khoản không tồn tại!";
                return res;
            }
            res.StatusCode = 200;
            return res;
                


        }

        public ResponseData<Customer> CheckRegister(Customer model)
        {
            ResponseData<Customer> res = new ResponseData<Customer>();
            res = _CustomerRepository.CheckRegisterClient(model);
            if(res.Data !=null)
            {
                res.StatusCode = 201;
                res.ErrorMessage = "Email đã tồn tại!";
                return res;
            }
            res.StatusCode = 200;
            return res;
        }
    }
}
