using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfusedDevelopProject.Core
{
    public class BasePageResultInfo
    {
        /// <summary>
        /// 行序号
        /// </summary>
        public virtual int RowNumber { get; set; }

        /// <summary>
        /// 最后更新时间（默认排序）
        /// </summary>
        public virtual DateTime UpdatedTime { get; set; }
    }

    /// <summary>
    /// 分页查询结果返回
    /// </summary>
    public class PageQueryResultInfo<T> where T : BasePageResultInfo
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public virtual int Total { get; set; }

        /// <summary>
        /// 数据集合
        /// </summary>
        public virtual IEnumerable<T> Rows { get; set; }
    }
}