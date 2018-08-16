using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfusedDevelopProject.Data
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class CDP_User : BaseDbEntity
    {
        /// <summary>
        /// 账户
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadIcon { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        public string WeChat { get; set; }
        /// <summary>
        /// 部门主键
        /// </summary>
        public string DepartmentId { get; set; }
        /// <summary>
        /// 角色主键
        /// </summary>
        public string RoleId { get; set; }
        /// <summary>
        /// 岗位主键
        /// </summary>
        public string DutyId { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>
        public bool IsEnabled { get; set; }       
    }
}