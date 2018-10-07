using lyq.Common;
using lyq.Common.Extension;
using lyq.Dto;
using lyq.Entities;
using lyq.IService;
using lyq.Service.Dto;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace lyq.Service
{
    public class UserService : IUserService
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
            Expression<Func<UserEntity, bool>> whereExpression = t => false;

            if (!string.IsNullOrWhiteSpace(username))
            {
                whereExpression.And(t => t.UserName == username);
            }
            if (!string.IsNullOrWhiteSpace(password))
            {
                whereExpression.And(t => t.Password == password);
            }

            var userEntity = baseService.GetAll(whereExpression).SingleOrDefaultAsync();
            var userDto = (await userEntity).MapTo<UserDto>();
            return userDto;
        }

        public async Task<int> AddAsync()
        {
            Task<int> result = Task.FromResult(0);
            bool IsExist = await baseService.GetAll<UserEntity>(t => t.UserName == "liyanqi").AnyAsync();
            if (!IsExist)
            {
                baseService.Add(new UserEntity
                {
                    UserName = "liyanqi",
                    RoleId = 222,
                    RealName = "liyanqi",
                    Phone = "18105207689",
                    Password = "asdfasdf"
                });

                result = baseService.SaveAsync();
            }
            return await result;
        }
    }
}
