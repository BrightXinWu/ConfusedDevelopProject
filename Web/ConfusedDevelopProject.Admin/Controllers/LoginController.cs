using CommonLibrary;
using ConfusedDevelopProject.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ConfusedDevelopProject.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        #region Login页面
        // GET: Login
        public ActionResult Login()
        {
            return View();
        } 
        #endregion

        #region 获取验证码
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VerifyCode()
        {
            var codeInfo = new YZMHelper();
            Session["Text"] = codeInfo.Text;
            MemoryStream ms = new MemoryStream();
            codeInfo.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return File(ms.ToArray(), @"image/Gif");
        }
        #endregion

        #region 登录验证
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="verifyCode">验证码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoginVerification(string userName, string password, string verifyCode)
        {
            if (verifyCode != Session["Text"].ToString())
            {
                return Json(new
                {
                    Succeed = false,
                    Data = "验证码错误！"
                });
            }
            var data = _loginService.LoginStatus(userName, password);
            if (!data)
            {
                return Json(new
                {
                    Succeed = data,
                    Data = "用户名或密码错误！"
                });
            }
            else
            {
                var ticket = new FormsAuthenticationTicket(0, userName, DateTime.Now,
                            DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", userName, password),
                            FormsAuthentication.FormsCookiePath);
                Session["UserName"] = userName;
                return Json(new
                {
                    Succeed = data,
                    Ticket = FormsAuthentication.Encrypt(ticket)
                });
            }
            
        }
        #endregion
    }
}