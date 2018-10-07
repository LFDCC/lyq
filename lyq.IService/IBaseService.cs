using lyq.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace lyq.IService
{
    public interface IBaseService : IDisposable
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        void Add<TEntity>(TEntity t) where TEntity : BaseEntity;
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        void Delete<TEntity>(TEntity t) where TEntity : BaseEntity;
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        int Delete<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : BaseEntity;

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        void Update<TEntity>(TEntity t) where TEntity : BaseEntity;
        /// <summary>
        /// 修改扩展方法
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="updateExpression"></param>
        /// <returns></returns>
        int Update<TEntity>(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updateExpression) where TEntity : BaseEntity;
        /// <summary>
        /// 修改扩展异步方法
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <param name="updateExpression"></param>
        /// <returns></returns>
        Task<int> UpdateAsync<TEntity>(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updateExpression) where TEntity : BaseEntity;
        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        int Save();
        /// <summary>
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        Task<int> SaveAsync();
        /// <summary>
        /// 获得一个IQueryable集合
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : BaseEntity;
    }
}
