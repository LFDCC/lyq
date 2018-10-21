using lyq.Dto;
using lyq.Entities;
using lyq.Infrastructure.Extension;
using lyq.IService;
using System.Threading.Tasks;

namespace lyq.Service
{
    public class LogService : ILogService
    {
        IBaseService baseService;
        public LogService(IBaseService _baseService)
        {
            baseService = _baseService;
        }

        public Task<int> AddAsync(LogDto logDto)
        {
            var logEntity = logDto.MapTo<LogEntity>();
            baseService.Add(logEntity);
            Task<int> result = baseService.SaveAsync();

            return result;
        }
    }
}
