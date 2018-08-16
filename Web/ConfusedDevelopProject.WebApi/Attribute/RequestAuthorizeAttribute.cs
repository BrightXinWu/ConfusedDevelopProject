using CommonLibrary;
using ConfusedDevelopProject.Core;
using ConfusedDevelopProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;
using Unity;

namespace ConfusedDevelopProject.WebApi
{
    /// <summary>
    /// 自定义此特性用于接口的身份验证
    /// </summary>
    public class RequestAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //从http请求的头里面获取身份验证信息，验证是否是请求发起方的ticket
            var authorization = actionContext.Request.Headers.Authorization;
            if ((authorization != null) && (authorization.Parameter != null))
            {
                //解密用户ticket,并校验用户名密码是否匹配
                var encryptTicket = authorization.Parameter;
                if (ValidateTicket(encryptTicket))
                {
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
            else
            {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }
        }

        /// <summary>
        /// 校验用户名密码（正式环境中应该是数据库校验）
        /// </summary>
        /// <param name="encryptTicket"></param>
        /// <returns></returns>
        private bool ValidateTicket(string encryptTicket)
        {
            //解密Ticket
            var strTicket = FormsAuthentication.Decrypt(encryptTicket).UserData;

            //从Ticket里面获取用户名和密码
            var index = strTicket.IndexOf("&");
            string strUser = strTicket.Substring(0, index);
            string strPwd = strTicket.Substring(index + 1);
            //TODO 验证用户名和密码
            var container = new UnityContainer();
            var repository = container.Resolve<IRepository>();
            //用户信息
            var userInfo = repository.FirstOrDefault<CDP_User>(m => m.Id == strUser);
            //密码信息
            var pwdInfo = repository.FirstOrDefault<Sys_UserLogOn>(m => m.UserId == strUser);
            //密码加密之后的信息
            var pwd = Encrypt.Encode(strPwd);
            if (userInfo != null && pwdInfo != null && pwdInfo.UserPassword == pwd)
            {
                container.Resolve<IUserContext>().WorkUserInfo = new UserInfo
                {
                    UserId = strUser
                };
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}