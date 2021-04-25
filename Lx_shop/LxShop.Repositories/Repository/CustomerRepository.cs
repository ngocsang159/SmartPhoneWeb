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
    public class CustomerRepository : GenericRepository<CustomerModel>, ICustomerRepository
    {
        

        public IPagedList<CustomerModel> PaggingCustomer(CustomerModel search1)
        {
            var query = (from C in db.Customers
                         join P in db.Provinces
                         on C.ProvinceId equals P.ProvinceId
                         join D in db.Districts
                        on C.DistrictId equals D.DistrictId
                         select new CustomerModel()
                         {
                              customer = C,
                              province = P,
                              district = D
                             
                         });
            return query.WhereIf(!string.IsNullOrEmpty(search1.customer.Customer_name),n=>n.customer.Customer_name.Contains(search1.customer.Customer_name)).OrderBy(n=>n.customer.CreatedDate).ToPagedList(search1.page_num.Value,search1.page_size.Value);

        }
        public ResponseData<Customer> CheckLoginClient(Customer model)
        {
            ResponseData<Customer> res = new ResponseData<Customer>();
          
            var userInput = db.Customers.Where(n => n.email == model.email|| n.phone == model.phone).FirstOrDefault();
            if(userInput != null && userInput.Password == Encryption.MD5Hash(model.Password))
            {
                res.Data = userInput;
            }
            return res;
        }

        public ResponseData<Customer> CheckRegisterClient(Customer model)
        {
            ResponseData<Customer> res = new ResponseData<Customer>();
            res.Data = db.Customers.Where(n => n.email == model.email).FirstOrDefault();
            return res;
        }
    }
}
