using ConfusedDevelopProject.Core;
using ConfusedDevelopProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfusedDevelopProject.Services
{
    /// <summary>
    /// 通用接口
    /// </summary>
    public class CommonService : ICommonService
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
        /// 通用接口
        /// </summary>
        /// <param name="repository">工作单元仓储</param>
        /// <param name="userContext">用户信息</param>
        public CommonService(IRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }
        #endregion

        #region 获取用户信息
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public CDP_User GetUserInfo(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                userId = _userContext.WorkUserInfo.UserId;
                return _repository.FirstOrDefault<CDP_User>(m => m.Id == userId);
            }
            return _repository.FirstOrDefault<CDP_User>(m => m.UserName == userId);
        } 
        #endregion
    }
}