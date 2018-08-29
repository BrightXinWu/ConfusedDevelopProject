using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfusedDevelopProject.Core
{
    public static class PageQueryExtend
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="source">查询源</param>
        /// <param name="queryInfo">查询对象</param>
        /// <param name="actionSet">设置值回调</param>
        /// <returns>查询结果</returns>
        public static PageQueryResultInfo<T> ParsePageQuery<T>(this IQueryable<T> source,
            BasePageQueryInfo queryInfo, Action<T> actionSet = null)
            where T : BasePageResultInfo, new()
        {
            var result = new PageQueryResultInfo<T>();

            if (queryInfo == null)
            {
                return result;
            }
            //充值当前页码
            if (queryInfo.PageNumber == 0)
            {
                queryInfo.PageNumber = 1;
            }
            //分页大小默认为10
            if (queryInfo.PageSize == 0)
            {
                queryInfo.PageSize = 10;
            }
            //起始页
            var startIndex = (queryInfo.PageNumber - 1) * queryInfo.PageSize;
            // 执行分页
            var pageSource = (IQueryable<T>)source.OrderByDescending(m=>m.UpdatedTime).Skip(startIndex).Take(queryInfo.PageSize);

            // 委托构造行数
            Func<T, int, T> func = (s, index) =>
            {
                var t = s;
                t.RowNumber = index + startIndex + 1;
                actionSet?.Invoke(t);
                return t;
            };

            // 总条数
            result.Total = source.Select(s => 1).Count();

            // 行数据
            result.Rows = pageSource.AsEnumerable().Select(func);

            return result;
        }
    }
}