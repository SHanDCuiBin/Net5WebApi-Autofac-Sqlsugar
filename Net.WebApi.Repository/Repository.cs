using SqlSugar;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApi.IRepository;

namespace WebApi.Repository
{
    public class BaseRepository<TEntity> : SimpleClient<TEntity>, IBaseRepository<TEntity> where TEntity : class, new()
    {
        public BaseRepository(ISqlSugarClient context = null) : base(context)
        {
            var configId = typeof(TEntity).GetCustomAttribute<TenantAttribute>().configId;
            if (configId.ToString() == "health_info")        //默认当前年份业务库
            {
                configId = "health_info" + DateTime.Now.Year;
            }
            base.Context = DbScoped.Sugar.GetConnection(configId).Context;
        }

        #region 事务

        /// <summary>
        /// 获取当前数据库上下文
        /// </summary>
        /// <returns></returns>
        public SqlSugarClient GetSqlSugarClient()
        {
            return DbScoped.Sugar;
        }

        /****************多租户事务*****************
          try
           {
               db.BeginTran();
               //你要处理的代码
               db.CommitTran();
           }
           catch (Exception)
           {
               db.RollbackTran();
                throw;
           }                   
        *********************************************/

        #endregion


        #region 【查询-异步操作】

        /// <summary>
        /// 查询--所有
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> QueryableAsync()
        {
            return await base.Context.Queryable<TEntity>().ToListAsync();
        }

        /// <summary>
        /// 查询--自定义查询
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> QueryableAsync(Expression<Func<TEntity, bool>> func)
        {
            return await base.Context.Queryable<TEntity>().Where(func).ToListAsync();
        }

        /// <summary>
        /// 查询--分页查询所有
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> QueryableAsync(int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<TEntity>().ToPageListAsync(page, size, total);
        }

        /// <summary>
        /// 查询--自定义分页查询
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> QueryableAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<TEntity>().Where(func).ToPageListAsync(page, size, total);
        }
        #endregion

        #region 【新增-异步操作】
        /// <summary>
        /// 新增--单实体新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>数据库受影响的行数</returns>
        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            return await base.Context.Insertable(entity).ExecuteCommandAsync();
        }

        /// <summary>
        /// 新增--批量实体新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>数据库受影响的行数</returns>
        public virtual async Task<int> CreateAsync(List<TEntity> entity)
        {
            return await base.Context.Insertable(entity).ExecuteCommandAsync();
        }
        #endregion

        #region 【删除-异步操作】
        /// <summary>
        /// 删除-自定义条件删除
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public virtual async Task<int> DelAsync(Expression<Func<TEntity, bool>> func)
        {
            return await base.Context.Deleteable<TEntity>().Where(func).ExecuteCommandAsync();
        }
        #endregion


        #region 【更新-异步操作】
        /// <summary>
        /// 更新-单实体更新（根据实体主键）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<int> EditAsync(TEntity entity)
        {
            return await base.Context.Updateable(entity).ExecuteCommandAsync(); ;
        }

        /// <summary>
        /// 更新-批量实体更新（根据实体主键）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<int> EditAsync(List<TEntity> entity)
        {
            return await base.Context.Updateable(entity).ExecuteCommandAsync(); ;
        }

        /// <summary>
        /// 更新-批量更新（实体无主键,根据指定列,进行更新）
        /// </summary>
        /// <param name="entity">实体集合</param>
        /// <param name="columnNames">指定列集合</param>
        /// <returns></returns>
        public virtual async Task<int> EditAsync(List<TEntity> entity, params string[] columnNames)
        {
            return await base.Context.Updateable(entity).WhereColumns(columnNames).ExecuteCommandAsync(); ;
        }

        /// <summary>
        /// 更新-单实体自定义条件更新
        /// </summary>
        /// <param name="entity">实体集合</param>
        /// <param name="columnNames">指定列集合</param>
        /// <returns></returns>
        public virtual async Task<int> EditAsync(TEntity entity, Expression<Func<TEntity, bool>> func)
        {
            return await base.Context.Updateable(entity).Where(func).ExecuteCommandAsync(); ;
        }
        #endregion
    }
}
