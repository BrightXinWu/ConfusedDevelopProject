using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfusedDevelopProject.Core.DbContexts
{
    /// <summary>
    /// DB上下文接口
    /// </summary>
    public interface IDbContext : IUnitOfWork
    {
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <typeparam name="TEntity">类型必须和数据库对应并且在Map文件设定映射关系</typeparam>
        /// <returns>表对象接口</returns>
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        /// <summary>
        /// 执行Sql查询
        /// </summary>
        /// <typeparam name="TEntity">查询类型</typeparam>
        /// <param name="commandText">sql文</param>
        /// <param name="parameters">参数</param>
        /// <returns>查询结果</returns>
        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
            where TEntity : class, new();
        /// <summary>
        /// 创建一个原始的SQL查询，将返回给定的泛型类型的元素。类型可以是任何类型的具有相匹配的列的名称从查询返回，或者可以是一个简单的原语类型属性。类型不必须是一个实体类型。这个查询的结果从未由即使对象的返回的类型是一个实体型的上下文跟踪。
        /// </summary>
        /// <typeparam name="TEntity">查询返回的对象的类型</typeparam>
        /// <param name="sql">sql文</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        List<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters) where TEntity : class, new();
        /// <summary>
        /// 对数据库执行给定的DDL/ DML命令。
        /// </summary>
        /// <param name="sql">sql文</param>
        /// <param name="doNotEnsureTransaction">false：事务执行不能保证，true：事务执行保证</param>
        /// <param name="timeout">超时：null为默认值</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        int ExeuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null,
            params object[] parameters);
        /// <summary>
        /// 执行追加/更新/删除sql文
        /// </summary>
        /// <param name="commandText">sql文</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        int ExecuteSqlCommand(string commandText, params object[] parameters);
        /// <summary>
        /// 分离实体
        /// </summary>
        /// <param name="entity"></param>
        void Detach(object entity);
        /// <summary>
        /// 获取或设置一个值，指示代理创建设置是否启用（EF中使用）
        /// </summary>
        bool ProxyCreationEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示自动检测设置的更改是否启用（EF中使用）
        /// </summary>
        bool AutoDetectChangesEnabled { get; set; }
        /// <summary>
        /// 附加对象到上下文
        /// </summary>
        /// <typeparam name="TEntity">附加类型</typeparam>
        /// <param name="item">附加对象</param>
        void Attach<TEntity>(TEntity item) where TEntity : class;
        /// <summary>
        /// 替换当前值
        /// </summary>
        /// <typeparam name="TEntity">替换类型</typeparam>
        /// <param name="original">旧对象</param>
        /// <param name="current">当前对象</param>
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;
    }
}
