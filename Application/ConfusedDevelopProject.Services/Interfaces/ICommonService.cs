using ConfusedDevelopProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfusedDevelopProject.Services
{
    /// <summary>
    /// 通用接口
    /// </summary>
    public interface ICommonService
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        CDP_User GetUserInfo(string userId);
    }
}
