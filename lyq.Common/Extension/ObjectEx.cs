﻿using LinqKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace lyq.Common.Extension
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ObjectEx
    {
        #region 表达式树扩展

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

        #region JSON扩展

        public static object ToJson(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject(Json);
        }

        public static string ToJson(this object obj, string format = "yyyy-MM-dd HH:mm:ss")
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }

        public static T ToObject<T>(this string Json)
        {
            return Json == null ? default(T) : JsonConvert.DeserializeObject<T>(Json);
        }

        public static List<T> ToList<T>(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<List<T>>(Json);
        }

        public static DataTable ToTable(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<DataTable>(Json);
        }

        public static JObject ToJObject(this string Json)
        {
            return Json == null ? JObject.Parse("{}") : JObject.Parse(Json.Replace("&nbsp;", ""));
        }

        #endregion JSON扩展

        public static int ConvertToIntBaseZero(this object o)
        {
            int intRtn = 0;

            if (o != null)
            {
                int.TryParse(o.ToString(), out intRtn);
            }

            return intRtn;
        }

        public static int ConvertToIntBaseNegativeOne(this object o)
        {
            int intRtn = -1;

            if (o != null && o.ToString() != string.Empty)
            {
                int.TryParse(o.ToString(), out intRtn);
            }

            return intRtn;
        }

        public static decimal ConvertToDecimalBaseMinValue(this object o)
        {
            decimal decRtn = decimal.MinValue;

            if (o == null || o == DBNull.Value)
            {
                decRtn = decimal.MinValue;
            }
            else
            {
                if (!decimal.TryParse(o.ToString(), out decRtn))
                {
                    decRtn = decimal.MinValue;
                }
            }

            return decRtn;
        }

        public static bool ConvertToBool(this object o)
        {
            bool bolRtn = false;

            try
            {
                if (o != null && o != DBNull.Value)
                {
                    string str = o.ToString().ToLower();

                    string[] trueStrings = new string[] { "true", "yes", "1", "√", "Y", "T", "是", "对" };

                    if (trueStrings.Contains(str))
                    {
                        bolRtn = true;
                    }
                }
            }
            catch
            {
            }

            return bolRtn;
        }

        public static string ConvertToString(this object o, string replaceString)
        {
            string strRtn = "";

            if (o == null || o == DBNull.Value)
            {
                strRtn = replaceString;
            }
            else
            {
                strRtn = o.ToString();
            }

            return strRtn;
        }

        public static decimal ConvertToDecimal(this object o)
        {
            decimal decRtn = 0m;

            if (o == null || o == DBNull.Value)
            {
                decRtn = 0m;
            }
            else
            {
                decimal.TryParse(o.ToString(), out decRtn);
            }

            return decRtn;
        }

        public static string ConvertToString(this object o)
        {
            return ConvertToString(o, string.Empty);
        }

        public static DateTime ConvertToDateTime(this object o)
        {
            DateTime dtRtn = DateTime.MinValue;

            try
            {
                if (o != null)
                {
                    DateTime.TryParse(o.ToString(), out dtRtn);
                }
            }
            catch
            {
            }

            return dtRtn;
        }
    }
}