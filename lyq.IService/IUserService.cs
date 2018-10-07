using lyq.Common;
using lyq.Dto;
using lyq.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace lyq.IService
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(string username,string password=null);
        Task<int> AddAsync();
        Task<Paging> GetPagingAsync(Expression<Func<UserEntity, bool>> whereExpression, int pageIndex, int pageSize);
    }
}
