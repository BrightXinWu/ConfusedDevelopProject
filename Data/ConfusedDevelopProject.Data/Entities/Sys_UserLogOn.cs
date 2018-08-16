using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfusedDevelopProject.Data
{
    public class Sys_UserLogOn : BaseDbEntity
    {
        /// <summary>
        /// 用户主键
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword { get; set; }
        /// <summary>
        /// 用户秘钥
        /// </summary>
        public string UserSecretkey { get; set; }
        /// <summary>
        /// 上一次访问时间
        /// </summary>
        public DateTime? PreviousVisitTime { get; set; }
        /// <summary>
        /// 最后访问时间
        /// </summary>
        public DateTime? LastVisitTime { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int LogOnCount { get; set; }
    }
}