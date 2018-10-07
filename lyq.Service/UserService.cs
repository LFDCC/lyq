using lyq.EntityFramework;
using lyq.Entities;
using lyq.IService;
using lyq.Utility.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lyq.Service
{
    public class UserService : IUserService
    {
        private readonly lyqContext context = new lyqContext();

        public async Task<Paging<UserEntity>> GetPagingAsync(Expression<Func<UserEntity, bool>> whereExpression, int pageIndex, int pageSize)
        {
            var list = context.UserEntities.Where(whereExpression);

            var total = list.CountAsync();

            var result = list.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToListAsync();

            var paper = new Paging<UserEntity>
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                total = await total,
                result = await result
            };

            return paper;
        }

        public Task<int> Add()
        {
            context.UserEntities.Add(new UserEntity
            {
                UserName = "liyanqi",
                RoleId = 222,
                RealName = "liyanqi",
                Phone = "18105207689",
                Password = "asdfasdf"
            });
            return context.SaveChangesAsync();
        }
        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
