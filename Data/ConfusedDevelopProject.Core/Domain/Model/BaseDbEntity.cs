using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfusedDevelopProject.Core.Domain.Model
{
    /// <summary>
    /// DB模型基类
    /// </summary>
    public abstract class BaseDbEntity
    {
        #region Properties
        /// <summary>
        /// 删除标识
        /// </summary>
        public virtual bool IsDelete { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreatedTime { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public virtual string CreatedBy { get; set; }
        /// <summary>
        /// 创建部门
        /// </summary>
        public virtual string CreatedDept { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime UpdatedTime { get; set; }
        /// <summary>
        /// 更新者
        /// </summary>
        public virtual string UpdatedBy { get; set; }
        /// <summary>
        /// 更新部门
        /// </summary>
        public virtual string UpdatedDept { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public virtual int? OrderIndex { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
        #endregion
    }
}