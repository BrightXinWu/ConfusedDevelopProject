using CommonLibrary;
using ConfusedDevelopProject.Core;
using ConfusedDevelopProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfusedDevelopProject.Services
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// 工作单元仓储
        /// </summary>
        private readonly IRepository _repository;

        #region MyRegion
        /// <summary>
        /// 通用接口
        /// </summary>
        /// <param name="repository">工作单元仓储</param>
        public UserService(IRepository repository)
        {
            _repository = repository;
        }
        #endregion

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="userId">用户Id</param>
        /// <param name="loginUser">当前登录用户</param>
        /// <returns></returns>
        public bool UpdatePwd(string password, string userId, string loginUser)
        {
            var encryptPwd = Encrypt.Encode(password);
            var pwdInfo = _repository.FirstOrDefault<Sys_UserLogOn>(m => m.UserId == userId);
            if (pwdInfo == null)
            {
                return false;
            }
            else
            {
                pwdInfo.UserPassword = encryptPwd;
                pwdInfo.UpdatedTime = DateTime.Now;
                pwdInfo.UpdatedBy = loginUser;
                _repository.Update(pwdInfo);
            }
            return true;
        }


        /// <summary>
        /// 获取系统人员信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PageQueryResultInfo<UserTableInfo> GetUserTable(BasePageQueryInfo query)
        {
            var data = _repository.All<CDP_User>(m => !m.IsDelete).Select(m=> new UserTableInfo
            {
                UserName = m.UserName,
                Birthday = m.Birthday,
                Gender = m.Gender,
                HeadIcon = m.HeadIcon,
                RealName = m.RealName,
                Email = m.Email,
                MobilePhone = m.MobilePhone,
                WeChat = m.WeChat,
                UpdatedTime = m.UpdatedTime
            });
            var result = data.ParsePageQuery(query);
            
            return result;
        }
    }
}