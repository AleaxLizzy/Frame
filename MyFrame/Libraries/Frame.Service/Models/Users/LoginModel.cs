using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Models.Users
{
    public class LoginModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 记住我
        /// </summary>
        public bool RemberMe { get; set; }
    }
}
