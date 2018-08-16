using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfusedDevelopProject.Core
{
    /// <summary>
    /// 操作结果返回
    /// </summary>
    public class ResultInfo
    {
        /// <summary>
        /// 返回结果是否成功
        /// </summary>
        public bool Succeed { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// 查询操作结果返回
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultInfo<T> : ResultInfo
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }
    }
}