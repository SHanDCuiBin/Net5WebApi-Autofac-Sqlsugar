using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.IRepository;
using WebApi.IService;

namespace WebApi.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        public IBaseRepository<TEntity> _iBaseRepository;

        /// <summary>
        /// 获取当前数据库上下文
        /// </summary>
        /// <returns></returns>
        public SqlSugarClient GetSqlSugarClient()
        {
            return _iBaseRepository.GetSqlSugarClient();
        }

        #region 新增
        /// <summary>
        /// 新增--单实体新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>数据库受影响的行数</returns>
        public Task<int> CreateAsync(TEntity entity)
        {
            return _iBaseRepository.CreateAsync(entity);
        }
        /// <summary>
        /// 新增--批量实体新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>数据库受影响的行数</returns>
        public Task<int> CreateAsync(List<TEntity> entity)
        {
            return _iBaseRepository.CreateAsync(entity);
        }
        #endregion

        #region MyRegion
        /// <summary>
        /// 删除-自定义条件删除
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Task<int> DelAsync(Expression<Func<TEntity, bool>> func)
        {
            return _iBaseRepository.DelAsync(func);
        }
        #endregion

        #region 更新
        /// <summary>
        /// 更新-单实体更新（根据实体主键）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<int> EditAsync(TEntity entity)
        {
            return _iBaseRepository.EditAsync(entity);
        }
        /// <summary>
        /// 更新-批量实体更新（根据实体主键）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<int> EditAsync(List<TEntity> entity)
        {
            return _iBaseRepository.EditAsync(entity);
        }
        /// <summary>
        /// 更新-批量更新（实体无主键,根据指定列,进行更新）
        /// </summary>
        /// <param name="entity">实体集合</param>
        /// <param name="columnNames">指定列集合</param>
        /// <returns></returns>
        public Task<int> EditAsync(List<TEntity> entity, params string[] columnNames)
        {
            return _iBaseRepository.EditAsync(entity, columnNames);
        }
        /// <summary>
        /// 更新-单实体自定义条件更新
        /// </summary>
        /// <param name="entity">实体集合</param>
        /// <param name="columnNames">指定列集合</param>
        /// <returns></returns>
        public Task<int> EditAsync(TEntity entity, Expression<Func<TEntity, bool>> func)
        {
            return _iBaseRepository.EditAsync(entity, func);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询--所有
        /// </summary>
        /// <returns></returns>
        public Task<List<TEntity>> QueryableAsync()
        {
            return _iBaseRepository.QueryableAsync();
        }
        /// <summary>
        /// 查询--自定义查询
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Task<List<TEntity>> QueryableAsync(Expression<Func<TEntity, bool>> func)
        {
            return _iBaseRepository.QueryableAsync(func);
        }
        /// <summary>
        /// 查询--分页查询所有
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Task<List<TEntity>> QueryableAsync(int page, int size, RefAsync<int> total)
        {
            return _iBaseRepository.QueryableAsync(page, size, total);
        }
        /// <summary>
        /// 查询--自定义分页查询
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Task<List<TEntity>> QueryableAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total)
        {
            return _iBaseRepository.QueryableAsync(func, page, size, total);
        }
        #endregion

    }
}
