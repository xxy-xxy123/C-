using Demo.Domain.Entities;

namespace Demo.Domain.IRepositories
{
    /// <summary>
    /// 仓储接口，用户定义用户相关的数据操作
    /// </summary>
    public interface IUserRepository
    {
        int Add(User user);
        List<User> GetAll();
        User GetByEmail(string email);
        User GetById(int id);
        int Update(User user);
    }
}