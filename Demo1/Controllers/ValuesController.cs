using Demo.Application.IService;
using Demo.Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        public ValuesController(IUserRepository userRepository1, IUserRepository userRepository2, 
            IUserService userService1, IUserService userService2) 
        {
            Console.WriteLine(userRepository1.GetHashCode());
            Console.WriteLine(userRepository2.GetHashCode());
            Console.WriteLine(userService1.GetHashCode());
            Console.WriteLine(userService2.GetHashCode());
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
