using LxShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LxShop.Commons;
using PagedList;

namespace LxShop.Repositories
{
    public partial interface IAccountAdminRepository
    {
        ResponseData<AccountAdmin> CheckLogin1(AccountAdmin model);
        ResponseData<AccountAdmin> CheckRegister1(AccountAdmin model);
        IPagedList<AccountAdmin> PaggingAjax(AccountAdmin search1);
    }
}
