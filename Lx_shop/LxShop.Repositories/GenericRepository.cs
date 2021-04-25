using LxShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxShop.Repositories
{
    public class GenericRepository<T>where T:class
    {
        protected readonly db_smartphoneEntities db;
        public GenericRepository()
        {
            db = new db_smartphoneEntities();
        }
    }
}
