using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfusedDevelopProject.Services
{
    public interface ILoginService
    {
        /// <summary>
        /// 登录是否正确
        /// </summary>
        /// <param name="userName">登录名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        bool LoginStatus(string userName, string password);
    }
}
