using Demo.Application.IService;
using Demo.Domain.Entities;
using Demo.Domain.IRepositories;

namespace Demo.Application.Service
{
    /// <summary>
    /// 业务实现，用户相关逻辑处理的具体实现方式
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// 依赖于用户仓储
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// 构造，初始化
        /// </summary>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user">包含账号密码的用户信息</param>
        /// <returns>返回成功/失败</returns>
        public bool Reg(User user)
        {
            // 1、检查
            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
            {
                return false;
            }

            // 2、记录注册信息
            user.RegTime = DateTime.Now;
            user.Status = true;

            // 3、保存用户信息
            int count = _userRepository.Add(user);

            // 4、返回结果
            return count > 0;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>返回成功/失败</returns>
        public bool Login(User user)
        {
            // 1、检查
            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
            {
                return false;
            }

            // 2、按邮箱获取目标信息
            var target = _userRepository.GetByEmail(user.Email);
            if (target == null)
            {
                return false;
            }

            // 3、密码错误
            if (!target.Password.Equals(user.Password))
            {
                return false;
            }

            // 4、更新登录信息
            target.LastLoginTime = DateTime.Now;
            _userRepository.Update(target);

            // 5、返回结果
            return true;
        }

        /// <summary>
        /// 返回用户详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        /// <summary>
        /// 检查邮箱是否存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ExistsByEmail(string email)
        {
            return _userRepository.GetByEmail(email) != null;
        }

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
