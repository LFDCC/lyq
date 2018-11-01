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

        public Task<int> AddAsync(LogErrorDto logDto)
        {
            var logEntity = logDto.MapTo<LogErrorEntity>();
            baseService.Add(logEntity);
            Task<int> result = baseService.SaveAsync();

            return result;
        }
    }
}
