using ConfusedDevelopProject.Core;
using ConfusedDevelopProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConfusedDevelopProject.WebApi
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //判断返回结果
            bool result = false;
            //controller上是否有特性CheckLogin,以及特性IsNeedLogin值
            var controllerAttrs = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(CheckLoginAttribute), false);
            if (controllerAttrs.Count() > 0)
            {
                var conAttr = controllerAttrs[0] as CheckLoginAttribute;
                if (conAttr != null)
                {
                    if (conAttr.IsNeedLogin)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            //action上是否有特性CheckLogin，以及特性的IsNeedLogin值
            var actionAttrs = filterContext.ActionDescriptor.GetCustomAttributes(typeof(CheckLoginAttribute), false);
            if (actionAttrs.Count() > 0)
            {
                var attr = actionAttrs[0] as CheckLoginAttribute;
                if (attr != null)
                {
                    if (attr.IsNeedLogin)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            if (!IsLogin() && result)
            {
                //如果没有登录，则跳至登陆页
                filterContext.Result = Redirect("/Login/Login");
            }
        }

        protected bool IsLogin()
        {
            if (Session["UserName"] != null)
                return true;

            return false;
        }
    }
}