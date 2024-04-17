using Demo.Application.IService;
using Demo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        /// <summary>
        /// 依赖于用户信息
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// 构建，初始化
        /// </summary>
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        /// <summary>
        /// 接口，用户详情
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns>返回用户JSON</returns>
        [Route("info")]
        public IActionResult Info(int id)
        {
            var user = _userService.GetById(id);
            return Json(user);
        }

        /// <summary>
        /// 接口，登录
        /// </summary>
        /// <param name="user">包含登录信息的对象</param>
        /// <returns>返回JSON</returns>
        [Route("login")]
        public IActionResult Login(User user)
        {
            var result = _userService.Login(user);
            return Json(result);
        }

        /// <summary>
        /// 接口，注册
        /// </summary>
        /// <param name="user">包含注册信息的对象</param>
        /// <returns>返回结果</returns>
        [Route("register")]
        public IActionResult Register(User user) 
        {
            var result = _userService.Reg(user);
            return Json(result);
        }

        /// <summary>
        /// 接口，获取所有用户信息
        /// </summary>
        /// <returns>返回JSON</returns>
        [Route("getAll")]
        public IActionResult GetAll()
        {
            var list = _userService.GetAll();
            return Json(list);
        }

        /// <summary>
        /// 接口，检查邮箱是否被占用
        /// </summary>
        /// <param name="email">邮箱地址</param>
        /// <returns>返回JSON</returns>
        [Route("exist")]
        public IActionResult ExistByEmail([FromForm]string email) 
        {
            var result = _userService.ExistsByEmail(email);
            return Json(result);
        }
    }
}
