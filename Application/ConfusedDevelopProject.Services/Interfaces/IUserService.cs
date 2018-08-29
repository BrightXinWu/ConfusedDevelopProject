using ConfusedDevelopProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfusedDevelopProject.Services
{
    public interface IUserService
    {
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="userId">用户Id</param>
        /// <param name="loginUser">当前登录用户</param>
        /// <returns></returns>
        bool UpdatePwd(string password, string userId, string loginUser);

        /// <summary>
        /// 获取系统人员信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PageQueryResultInfo<UserTableInfo> GetUserTable(BasePageQueryInfo query);
    }
}
