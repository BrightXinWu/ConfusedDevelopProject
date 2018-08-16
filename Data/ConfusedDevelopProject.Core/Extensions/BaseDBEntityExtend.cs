using ConfusedDevelopProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfusedDevelopProject.Core
{
    /// <summary>
    /// 数据库模型扩展
    /// </summary>
    public static class BaseDBEntityExtend
    {
        /// <summary>
        /// 初始化追加模型信息
        /// </summary>
        /// <typeparam name="TEntity">类型</typeparam>
        /// <param name="entity">实体对象</param>
        /// <param name="context">上下文</param>
        public static void InitCreateEntity<TEntity>(this TEntity entity, IUserContext context)
            where TEntity : BaseDbEntity
        {
            entity.CreatedBy = context.WorkUserInfo.UserId;
            entity.CreatedTime = DateTime.Now;
            entity.UpdatedBy = context.WorkUserInfo.UserId;
            entity.UpdatedTime = DateTime.Now;
        }

        /// <summary>
        /// 初始化更新模型信息
        /// </summary>
        /// <typeparam name="TEntity">类型</typeparam>
        /// <param name="entity">实体对象</param>
        /// <param name="context">上下文</param>
        public static void InitUpdateEntity<TEntity>(this TEntity entity, IUserContext context)
            where TEntity : BaseDbEntity
        {
            entity.UpdatedBy = context.WorkUserInfo.UserId;
            entity.UpdatedTime = DateTime.Now;
        }
    }
}