using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {

        /// <summary>
        /// 获取当前数据库的上下文
        /// </summary>
        /// <returns></returns>
        public SqlSugarClient GetSqlSugarClient();

        #region 【查询-异步操作】
        /// <summary>
        /// 查询--所有
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<List<TEntity>> QueryableAsync();

        /// <summary>
        /// 查询--自定义查询
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Task<List<TEntity>> QueryableAsync(Expression<Func<TEntity, bool>> func);

        /// <summary>
        /// 查询--分页查询所有
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Task<List<TEntity>> QueryableAsync(int page, int size, RefAsync<int> total);

        /// <summary>
        /// 查询--自定义分页查询
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Task<List<TEntity>> QueryableAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total);
        #endregion

        #region 【新增-异步操作】
        /// <summary>
        /// 新增--单实体新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>数据库受影响的行数</returns>
        public Task<int> CreateAsync(TEntity entity);

        /// <summary>
        /// 新增--批量实体新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>数据库受影响的行数</returns>
        public Task<int> CreateAsync(List<TEntity> entity);
        #endregion

        #region 【删除-异步操作】
        /// <summary>
        /// 删除-自定义条件删除
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Task<int> DelAsync(Expression<Func<TEntity, bool>> func);
        #endregion

        #region 【更新-异步操作】
        /// <summary>
        /// 更新-单实体更新（根据实体主键）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<int> EditAsync(TEntity entity);

        /// <summary>
        /// 更新-批量实体更新（根据实体主键）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<int> EditAsync(List<TEntity> entity);

        /// <summary>
        /// 更新-批量更新（实体无主键,根据指定列,进行更新）
        /// </summary>
        /// <param name="entity">实体集合</param>
        /// <param name="columnNames">指定列集合</param>
        /// <returns></returns>
        public Task<int> EditAsync(List<TEntity> entity, params string[] columnNames);

        /// <summary>
        /// 更新-单实体自定义条件更新
        /// </summary>
        /// <param name="entity">实体集合</param>
        /// <param name="columnNames">指定列集合</param>
        /// <returns></returns>
        public Task<int> EditAsync(TEntity entity, Expression<Func<TEntity, bool>> func);
        #endregion
    }
}
