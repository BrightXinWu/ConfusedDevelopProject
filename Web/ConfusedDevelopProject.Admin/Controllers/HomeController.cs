using ConfusedDevelopProject.Core;
using ConfusedDevelopProject.Services;
using ConfusedDevelopProject.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConfusedDevelopProject.Admin.Controllers
{ 
    [CheckLogin(true)]
    public class HomeController : BaseController
    {
        /// <summary>
        /// 通用接口
        /// </summary>
        private readonly ICommonService _commonService;
        /// <summary>
        /// 用户接口
        /// </summary>
        private readonly IUserService _userService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commonService"></param>
        public HomeController(ICommonService commonService, IUserService userService)
        {
            _commonService = commonService;
            _userService = userService;
        }

        #region 首页
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public ActionResult Index(string ticket)
        {
            ViewBag.Ticket = ticket;
            var userInfo = _commonService.GetUserInfo(Session["UserName"].ToString());
            ViewBag.RealName = userInfo.RealName;
            ViewBag.Id = userInfo.Id;
            return View();
        } 
        #endregion



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="password"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdatePwd(string password,string userId)
        {
            var loginUser = Session["UserName"].ToString();
            var result = _userService.UpdatePwd(password, userId, loginUser);
            if (result)
            {
                return Json(new { Succeed = result, Message = "修改成功！" });
            }
            else
            {
                return Json(new { Succeed = result, Message = "修改失败！" });
            }
            
        }

        /// <summary>
        /// 获取用户列表信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUserTable(BasePageQueryInfo query)
        {
            var data = _userService.GetUserTable(query);
            return Json(new {total = data.Total,rows = data.Rows }, JsonRequestBehavior.AllowGet);
        }
    }
}