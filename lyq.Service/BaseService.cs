using lyq.Entities;
using lyq.EntityFramework;
using lyq.Infrastructure.Ioc;
using lyq.IService;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace lyq.Service
{
    public class BaseService : IBaseService, IDependency
    {
        protected lyqContext dbContext = new lyqContext();

        /// <summary>
        /// 增加
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual void Add<TEntity>(TEntity t) where TEntity : BaseEntity
        {
            dbContext.Entry(t).State = EntityState.Added;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual void Delete<TEntity>(TEntity t) where TEntity : BaseEntity
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public virtual int Delete<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : BaseEntity
        {
            int result = dbContext.Set<TEntity>().Where(whereExpression).Delete();
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual void Update<TEntity>(TEntity t) where TEntity : BaseEntity
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression">条件</param>
        /// <param name="updateExpression">表达式</param>
        /// <returns></returns>
        public virtual int Update<TEntity>(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updateExpression) where TEntity : BaseEntity
        {
            var result = dbContext.Set<TEntity>().Where(whereExpression).Update(updateExpression);
            return result;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression">条件</param>
        /// <param name="updateExpression">表达式</param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync<TEntity>(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updateExpression) where TEntity : BaseEntity
        {
            var result = dbContext.Set<TEntity>().Where(whereExpression).UpdateAsync(updateExpression);
            return result;
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public virtual int Save()
        {
            return dbContext.SaveChanges();
        }
        /// <summary>
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        public virtual Task<int> SaveAsync()
        {
            var result = dbContext.SaveChangesAsync();
            return result;
        }
        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : BaseEntity
        {
            return dbContext.Set<TEntity>().Where(whereExpression);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
