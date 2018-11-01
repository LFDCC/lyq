﻿using lyq.IEntities;
using System;

namespace lyq.Entities
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class LogOperEntity : BaseEntity, ICreateEntity
    {
        /// <summary>
        /// 请求的地址
        /// </summary>
        public string RequestUrl { get; set; }
        /// <summary>
        /// 请求方式
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// Query参数
        /// </summary>
        public string Query { get; set; }
        /// <summary>
        /// Form参数
        /// </summary>
        public string Form { get; set; }
        /// <summary>
        /// 客户端描述
        /// </summary>
        public string Client { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 操作耗时（ms）
        /// </summary>
        public long ElapsedTime { get; set; }
        /// <summary>
        /// 日志信息，操作描述
        /// </summary>
        public string Message { get; set; }

        public int? CreateUserId { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}