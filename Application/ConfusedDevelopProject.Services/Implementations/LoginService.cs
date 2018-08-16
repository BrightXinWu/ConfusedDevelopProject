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
    /// 登录接口
    /// </summary>
    public class LoginService : ILoginService
    {
        /// <summary>
        /// 工作单元仓储
        /// </summary>
        private readonly IRepository _repository;
        /// <summary>
        /// 用户信息
        /// </summary>
        private readonly IUserContext _userContext;

        #region MyRegion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository">工作单元仓储</param>
        /// <param name="userContext">用户信息</param>
        public LoginService(IRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        } 
        #endregion

        #region 判断登录是否正确
        /// <summary>
        /// 判断登录是否正确
        /// </summary>
        /// <param name="userName">登录名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool LoginStatus(string userName, string password)
        {
            //获取用户信息
            var userInfo = _repository.FirstOrDefault<CDP_User>(m => m.UserName == userName);
            //如果用户信息为null，返回false
            if (userInfo == null)
            {
                return false;
            }
            //获取用户密码信息，
            var pwdInfo = _repository.FirstOrDefault<Sys_UserLogOn>(m => m.UserId == userInfo.Id);
            //如果用户密码信息为null，返回false
            if (pwdInfo == null)
            {
                return false;
            }
            //密码加密之后的信息
            var pwd = Encrypt.Encode(password);
            //判断密码是否正确
            if (pwd == pwdInfo.UserPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <returns></returns>
        public ResultInfo UpdateLoginInfo(string userId,string password)
        {
            //用户密码信息
            var pwdInfo = _repository.FirstOrDefault<Sys_UserLogOn>(m => m.UserId == userId);
            if (pwdInfo == null)
            {
                return new ResultInfo
                {
                    Succeed = false,
                    Message = "没有用户密码信息！"
                };
            }
            //用户密码加密存入数据库
            pwdInfo.UserPassword = Encrypt.Encode(password);
            pwdInfo.InitUpdateEntity(_userContext);
            _repository.Update(pwdInfo);
            return new ResultInfo
            {
                Succeed = true
            };
        }
    }
}