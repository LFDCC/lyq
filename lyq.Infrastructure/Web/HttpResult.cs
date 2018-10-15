namespace lyq.Infrastructure.Web
{
    public class HttpResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public ResultState status { get; set; }
        /// <summary>
        /// 结果
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }
    }

    public enum ResultState
    {
        /// <summary>
        /// 成功
        /// </summary>
        success = 200,
        /// <summary>
        /// 失败
        /// </summary>
        fail = 201,
        /// <summary>
        /// 异常
        /// </summary>
        error = 202,
        /// <summary>
        /// 超时
        /// </summary>
        timeout = 204
    }
}
