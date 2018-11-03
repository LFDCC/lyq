using lyq.Dto;
using System.Threading.Tasks;

namespace lyq.IService
{
    public interface ILogService
    {
        Task<int> AddErrorLogAsync(ErrorLogDto logDto);
        Task<int> AddLoginLogAsync(LoginLogDto logDto);
    }
}
