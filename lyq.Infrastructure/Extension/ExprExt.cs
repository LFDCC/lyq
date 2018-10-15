using LinqKit;
using System;
using System.Linq.Expressions;

namespace lyq.Infrastructure.Extension
{
    public static class ExprExt
    {
        #region 表达式树扩展
        /// <summary>
        /// 初始化条件True
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> True<T>()
        {
            return PredicateBuilder.New<T>(true);
        }
        /// <summary>
        /// 初始化条件False
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> False<T>()
        {
            return PredicateBuilder.New<T>(false);
        }

        /// <summary>
        /// 合并表达式 expr1 AND expr2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return PredicateBuilder.And(expr1, expr2);
        }

        /// <summary>
        /// 合并表达式 expr1 Or expr2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return PredicateBuilder.Or(expr1, expr2);
        }

        #endregion 表达式树扩展
    }
}
