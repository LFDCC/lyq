using lyq.EntityFramework;
using lyq.IService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace lyq.Service
{
    class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected lyqContext dbContext = new lyqContext();

        /// <summary>
        /// 增加
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual void Add(TEntity t)
        {
            dbContext.Entry(t).State = EntityState.Added;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual void Delete(TEntity t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public virtual int Delete(Expression<Func<TEntity, bool>> whereExpression)
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
        public virtual void Update(TEntity t)
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
        public virtual int Update(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updateExpression)
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
        public virtual Task<int> UpdateAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updateExpression)
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
        /// 获取一个实体
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public virtual Task<TEntity> GetEntity(Expression<Func<TEntity, bool>> whereExpression)
        {
            return dbContext.Set<TEntity>().SingleOrDefaultAsync();
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public virtual Task<List<TEntity>> GetEntities(Expression<Func<TEntity, bool>> whereExpression)
        {
            return dbContext.Set<TEntity>().ToListAsync();
        }


        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
