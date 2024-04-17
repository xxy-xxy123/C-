using Demo.Domain.Entities;

namespace Demo.Application.IService
{
    public interface IUserService
    {
        bool ExistsByEmail(string email);
        List<User> GetAll();
        User GetById(int id);
        bool Login(User user);
        bool Reg(User user);
    }
}