using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxShop.Commons
{
    public class ResponseData<T>
    {
        /// <summary>
        /// StatusCode:200 thành công
        /// </summary>
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}
