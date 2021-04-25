using LxShop.Commons;
using LxShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace LxShop.Services
{
    public interface IAccountAdminService
    {
        ResponseData<AccountAdmin> CheckLogin(AccountAdmin model);
        ResponseData<AccountAdmin> CheckRegister(AccountAdmin model);
        IPagedList<AccountAdmin> PaggingAjax(AccountAdmin search);
    }
}
