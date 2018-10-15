using AutoMapper;
using System;
using System.Collections.Generic;

namespace lyq.Infrastructure.Extension
{
    public static class MapperExt
    {
        #region AutoMapper扩展

        /// <summary>
        /// 对象到对象
        /// </summary>
        /// <typeparam name="Destination"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Destination MapTo<Destination>(this object obj)
        {
            if (obj == null) return default(Destination);            
            return Mapper.Map<Destination>(obj);
        }

        /// <summary>
        /// 转换成List
        /// </summary>
        /// <typeparam name="Source"></typeparam>
        /// <typeparam name="Destination"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<Destination> MapToList<Source, Destination>(this List<Source> obj)
        {
            if (obj == null) throw new ArgumentNullException();
            return Mapper.Map<List<Source>, List<Destination>>(obj);
        }

        #endregion
    }
}
