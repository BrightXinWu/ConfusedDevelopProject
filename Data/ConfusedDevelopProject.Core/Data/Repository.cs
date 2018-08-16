using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace ConfusedDevelopProject.Core
{
    /// <summary>
    /// 工作单元仓储
    /// </summary>
    public partial class Repository : IRepository
    {
        #region 声明


        private readonly IDbContext _context;


        #endregion

        #region 注入

        public Repository(IDbContext context)
        {
            this._context = context;
        }

        #endregion

        #region Methods
        /// <summary>
        /// 查询满足条件的第一个
        /// </summary>
        /// <typeparam name="TEntity">返回值类型</typeparam>
        /// <param name="criteria">查询条件</param>
        /// <returns>查询结果</returns>
        public TEntity FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return _context.Set<TEntity>().FirstOrDefault(criteria);
        }

        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <typeparam name="TEntity">返回值类型</typeparam>
        /// <param name="keyValues">主键值</param>
        /// <returns>查询结果</returns>
        public TEntity FindById<TEntity>(string id) where TEntity : class
        {
            return _context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// 追加对象
        /// </summary>
        /// <typeparam name="TEntity">参数类型</typeparam>
        /// <param name="entity">追加对象</param>
        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                return;
            }
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// 异步追加对象并且提交
        /// </summary>
        /// <typeparam name="TEntity">参数类型</typeparam>
        /// <param name="entity">追加对象</param>
        /// <returns></returns>
        public Task<int> InsertAsyncAndCommit<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                return Task.FromResult(0);
            }
            _context.Set<TEntity>().Add(entity);
            return (_context as DbContext).SaveChangesAsync();
        }

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <typeparam name="TEntity">参数类型</typeparam>
        /// <param name="entity">需要更新的实体</param>
        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                return;
            }
            _context.Set<TEntity>().Attach(entity);
            _context.Update(entity);
        }



        /// <summary>
        /// 删除对象
        /// </summary>
        /// <typeparam name="TEntity">参数类型</typeparam>
        /// <param name="entity">需要删除的实体</param>
        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                return;
            }
            this._context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }



        /// <summary>
        /// 表接口
        /// </summary>
        /// <typeparam name="TEntity">查询类型</typeparam>
        ///  <param name="criteria">条件表达式</param>
        /// <returns>当前类型的表接口</returns>
        public IQueryable<TEntity> All<TEntity>(Expression<Func<TEntity, bool>> criteria = null) where TEntity : class
        {
            return criteria == null ? _context.Set<TEntity>() : _context.Set<TEntity>().Where(criteria);
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <typeparam name="TEntity">查询类型</typeparam>
        ///  <param name="criteria">条件表达式</param>
        /// <returns>当前条件是否存在</returns>
        public bool Any<TEntity>(Expression<Func<TEntity, bool>> criteria = null) where TEntity : class
        {
            return All(criteria).Select(s => 1).Distinct().Any();
        }



        #endregion

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public int UpdateByExpression<TEntity>(Expression<Func<TEntity, TEntity>> updateExpression, Expression<Func<TEntity, bool>> criteria = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int DeleteByExpression<TEntity>(Expression<Func<TEntity, bool>> criteria = null) where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}