using lyq.Dto;
using lyq.Entities;
using lyq.Infrastructure.Extension;
using lyq.Infrastructure.Ioc;
using lyq.IService;
using System.Threading.Tasks;

namespace lyq.Service
{
    public class LogService : ILogService, IDependency
    {
        IBaseService baseService;
        public LogService(IBaseService _baseService)
        {
            baseService = _baseService;
        }
        /// <summary>
        /// 添加错误日志
        /// </summary>
        /// <param name="logDto"></param>
        /// <returns></returns>
        public Task<int> AddErrorLogAsync(ErrorLogDto logDto)
        {
            var logEntity = logDto.MapTo<ErrorLogEntity>();
            baseService.Add(logEntity);
            Task<int> result = baseService.SaveAsync();

            return result;
        }
        /// <summary>
        /// 添加登录日志
        /// </summary>
        /// <param name="logDto"></param>
        /// <returns></returns>
        public Task<int> AddLoginLogAsync(LoginLogDto logDto)
        {
            var logEntity = logDto.MapTo<LoginLogEntity>();
            baseService.Add(logEntity);
            Task<int> result = baseService.SaveAsync();

            return result;
        }
    }
}
