using lyq.Dto;
using System.Threading.Tasks;

namespace lyq.IService
{
    public interface ILogService
    {
        Task<int> AddAsync(LogErrorDto logDto);
    }
}
