using LxShop.Commons;
using LxShop.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxShop.Services
{
    public class AccountAdminService : GenericService<AccountAdmin>, IAccountAdminService
    {
        public ResponseData<AccountAdmin> CheckLogin(AccountAdmin model)
        {
            //xử lý các điều kiện kiểm tra dữ liệu từ request gửi lên
            ResponseData<AccountAdmin> res = new ResponseData<AccountAdmin>();
            if(string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                res.StatusCode = 201;
                res.ErrorMessage = "Đăng nhập không thành công";
                return res;
            }
            //sau khi kiểm tra hết các điều kiện thì chuyển dữ liệu này xuống
            //Repository để nó thực hiện vào DB để kiểm tra
            res = _AccountAdminRepository.CheckLogin1(model);
          
            //kiểm tra kết quả sau khi truy vấn


            if (res.Data == null)
            {
                res.StatusCode = 201;
                res.ErrorMessage = "Đăng nhập không thành công";
                return res;
            }
            res.StatusCode = 200;
            return res;
          
            
        }
        public ResponseData<AccountAdmin> CheckRegister(AccountAdmin model)
        {
            ResponseData<AccountAdmin> res = new ResponseData<AccountAdmin>();
            res = _AccountAdminRepository.CheckRegister1(model);
            if (res.Data != null)
            {
                res.StatusCode = 201;
                res.ErrorMessage = "Tên đăng nhập đã tồn tại";
                return res;
            }
            res.StatusCode = 200;
            return res;
        }

        public IPagedList<AccountAdmin> PaggingAjax(AccountAdmin search)
        {
            if(search == null)
            {
                search = new AccountAdmin();
            }
            search.page_num = search.page_num ?? 1;
            if(search.page_size == null)
            {
                search.page_size = 7;
            }
            return _AccountAdminRepository.PaggingAjax(search);
          
        }
    }
}
