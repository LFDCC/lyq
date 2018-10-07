using lyq.Entities;
using lyq.Utility.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lyq.IService
{
    public interface IUserService: IDisposable
    {
        Task<int> Add();
        Task<Paging<UserEntity>> GetPagingAsync(Expression<Func<UserEntity, bool>> whereExpression, int pageIndex, int pageSize);
    }
}
