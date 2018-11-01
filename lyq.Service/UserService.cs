using lyq.Dto;
using lyq.Entities;
using lyq.Infrastructure.Extension;
using lyq.Infrastructure.Ioc;
using lyq.Infrastructure.Web;
using lyq.IService;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace lyq.Service
{
    public class UserService : IUserService, IDependency
    {
        IBaseService baseService;
        public UserService(IBaseService _baseService)
        {
            baseService = _baseService;
        }
        public async Task<Paging> GetPagingAsync(Expression<Func<UserEntity, bool>> whereExpression, int pageIndex, int pageSize)
        {
            var list = baseService.GetAll(whereExpression).AsNoTracking();

            var total = list.CountAsync();

            var result = list.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToListAsync();

            var paper = new Paging
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                total = await total,
                data = await result
            };

            return paper;
        }
        /// <summary>
        /// 根据用户名/密码获取用户对象
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public async Task<UserDto> GetUserAsync(string username, string password = null)
        {
            Expression<Func<UserEntity, bool>> whereExpression = ExprExt.True<UserEntity>();
            
            if (!string.IsNullOrWhiteSpace(username))
            {
                whereExpression = whereExpression.And(t => t.UserName == username);
            }
            if (!string.IsNullOrWhiteSpace(password))
            {
                whereExpression = whereExpression.And(t => t.Password == password);
            }
            
            var userEntity = await baseService.GetAll(whereExpression).AsNoTracking().FirstOrDefaultAsync();
            var userDto = userEntity.MapTo<UserDto>();
            return userDto;
        }

        public async Task<int> AddAsync(UserDto userDto)
        {
            Task<int> result = Task.FromResult(0);
            bool IsExist = await baseService.GetAll<UserEntity>(t => t.UserName == "liyanqi").AnyAsync();
            if (!IsExist)
            {
                var userEntity = userDto.MapTo<UserEntity>();
                baseService.Add(userEntity);

                result = baseService.SaveAsync();
            }
            return await result;
        }
    }
}
