using LxShop.Commons;
using LxShop.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxShop.Repositories
{
    public class AccountAdminRepository : GenericRepository<AccountAdmin>, IAccountAdminRepository
    {
        public ResponseData<AccountAdmin> CheckLogin1(AccountAdmin model)
        {
            ResponseData<AccountAdmin> res = new ResponseData<AccountAdmin>();
            //thực thi kết nối 
          var userInput = db.AccountAdmins.Where(n => (n.Username == model.Username || n.Email == model.Email)).FirstOrDefault();
            if(userInput != null && userInput.Password == Encryption.MD5Hash(model.Password))
            {
                res.Data = userInput;
            }
            
           
            //Db truy vấn kết quả
            return res;

            
        }

        public ResponseData<AccountAdmin> CheckRegister1(AccountAdmin model)
        {
            ResponseData<AccountAdmin> res = new ResponseData<AccountAdmin>();
            res.Data = db.AccountAdmins.Where(n => (n.Username == model.Username || n.Email == model.Email||n.Displayname == model.Displayname)).FirstOrDefault();
            return res;
        }

        public IPagedList<AccountAdmin> PaggingAjax(AccountAdmin search1)
        {
            //IQueryable<AccountAdmin> source = db.AccountAdmins.AsQueryable();
            //if (!string.IsNullOrEmpty(search1.Displayname))
            //{
            //    source.Where(n => n.Displayname.Contains(search1.Displayname));
            //}
            return db.AccountAdmins.AsQueryable()
                .WhereIf(!string.IsNullOrEmpty(search1.Username),n=>n.Username.Contains(search1.Username))//IqueryAble
                .WhereIf(!string.IsNullOrEmpty(search1.Displayname), n => n.Displayname.Contains(search1.Displayname)).OrderBy(n => n.Username).ToPagedList(search1.page_num.Value,search1.page_size.Value);
           
        }
    }
}
