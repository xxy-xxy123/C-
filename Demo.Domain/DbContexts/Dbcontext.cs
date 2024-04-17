using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Entities;

namespace Demo.Domain.DbContexts
{
    /// <summary>
    /// 数据库上下文，模拟数据库相关业务
    /// </summary>
    public class Dbcontext
    {
        /// <summary>
        /// 集合，用户信息，模拟用户表
        /// </summary>
        public static List<User> Users = new List<User>()
        {
            new User() { Id = 1, Email = "zhangsan@qq.com", Password = "zs123456", UserName = "张三", RegTime = DateTime.Now, LastLoginTime = DateTime.Now, Status = true},
            new User() { Id = 2, Email = "lisi@qq.com", Password = "ls123456", UserName = "李四", RegTime = DateTime.Now, LastLoginTime = DateTime.Now, Status = false},
            new User() { Id = 3, Email = "wangwuzhangsan@qq.com", Password = "wwzs123456", UserName = "王五", RegTime = DateTime.Now, LastLoginTime = DateTime.Now, Status = true},
        };
    }
}
