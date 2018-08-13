using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConfusedDevelopProject.Core
{
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// 查询满足条件的第一个
        /// </summary>
        /// <typeparam name="TEntity">返回值类型</typeparam>
        /// <param name="criteria">查询条件</param>
        /// <returns>查询结果</returns>
        TEntity FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <typeparam name="TEntity">返回值类型</typeparam>
        /// <param name="id">主键值</param>
        /// <returns>查询结果</returns>
        TEntity FindById<TEntity>(string id) where TEntity : class;

        /// <summary>
        /// 追加对象
        /// </summary>
        /// <typeparam name="TEntity">参数类型</typeparam>
        /// <param name="entity">追加对象</param>
        void Insert<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// 异步追加对象并且提交
        /// </summary>
        /// <typeparam name="TEntity">参数类型</typeparam>
        /// <param name="entity">追加对象</param>
        /// <returns></returns>
        Task<int> InsertAsyncAndCommit<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <typeparam name="TEntity">参数类型</typeparam>
        /// <param name="entity">需要更新的实体</param>
        void Update<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// EF扩展更新
        /// </summary>
        /// <typeparam name="TEntity">参数类型</typeparam>
        /// <param name="updateExpression">更新表达式</param>
        /// <param name="criteria">查询表达式</param>
        /// <returns></returns>        
        int UpdateByExpression<TEntity>(Expression<Func<TEntity, TEntity>> updateExpression,
            Expression<Func<TEntity, bool>> criteria = null) where TEntity : class;

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <typeparam name="TEntity">参数类型</typeparam>
        /// <param name="entity">需要删除的实体</param>
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// EF扩展删除
        /// </summary>
        /// <typeparam name="TEntity">参数类型</typeparam>
        /// <param name="criteria">查询表达式</param>
        /// <returns></returns>
        int DeleteByExpression<TEntity>(Expression<Func<TEntity, bool>> criteria = null) where TEntity : class;

        /// <summary>
        /// 表接口
        /// </summary>
        /// <typeparam name="TEntity">查询类型</typeparam>
        ///  <param name="criteria">条件表达式</param>
        /// <returns>当前类型的表接口</returns>
        IQueryable<TEntity> All<TEntity>(Expression<Func<TEntity, bool>> criteria = null) where TEntity : class;

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <typeparam name="TEntity">查询类型</typeparam>
        ///  <param name="criteria">条件表达式</param>
        /// <returns>当前条件是否存在</returns>
        bool Any<TEntity>(Expression<Func<TEntity, bool>> criteria = null) where TEntity : class;

    }
}
