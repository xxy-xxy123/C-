using Demo.Domain.DbContexts;
using Demo.Domain.Entities;
using Demo.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.NH.Repositories
{
    /// <summary>
    /// 仓储，用户相关数据操作
    /// </summary>
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
            Console.WriteLine("现在使用的是 NH 的用户仓储");
        }

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>返回受影响行数</returns>
        public int Add(User user)
        {
            Dbcontext.Users.Add(user);
            return 1;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>返回受影响行数</returns>
        public int Update(User user)
        {
            var target = Dbcontext.Users.Single(x => x.Id == user.Id);

            target.Password = user.Password;
            target.Status = user.Status;
            target.LastLoginTime = user.LastLoginTime;
            target.UserName = user.UserName;

            return 1;
        }

        /// <summary>
        /// 通过用户编号查询用户信息
        /// </summary>
        /// <param name="id">用户账号</param>
        /// <returns>返回用户信息</returns>
        public User GetById(int id)
        {
            return Dbcontext.Users.SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        ///通过邮箱账号查询用户信息
        /// </summary>
        /// <param name="email">用户邮箱</param>
        /// <returns>返回用户信息</returns>
        public User GetByEmail(string email)
        {
            // StringComparison.OrdinalIgnoreCase 忽略大小写
            return Dbcontext.Users.SingleOrDefault(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns>返回用户信息</returns>
        public List<User> GetAll()
        {
            return Dbcontext.Users;
        }
    }
}
