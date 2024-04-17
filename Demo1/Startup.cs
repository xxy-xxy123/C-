using Autofac;
using Autofac.Extensions.DependencyInjection;
using Demo.Application.IService;
using Demo.Application.Service;
using Demo.Data.EF.Repositories;
using Demo.Domain.IRepositories;

namespace Demo1
{
    public class Startup
    {
        //public IConfiguration Configuration { get; }

        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // 注册类型等服务
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserService>().As<IUserService>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // 添加对MVC控制器的支持  
            services.AddControllers();

            // 添加对API端点元数据的探索支持，这通常用于Swagger或API文档生成  
            services.AddEndpointsApiExplorer();

            // 添加Swagger生成器的服务，用于生成API文档  
            services.AddSwaggerGen();

            // 添加对Razor Pages的支持，用于构建动态网页  
            services.AddRazorPages();
           

            // 将IUserRepository接口映射到UserRepository实现，注册为Transient生命周期（每次请求时都会创建新的实例）  
            // services.AddScoped<IUserRepository, UserRepository>();

            // 将IUserService接口映射到UserService实现，注册为Transient生命周期（每次请求时都会创建新的实例）  
            //services.AddTransient<IUserService, UserService>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                // 在生产环境中，你可能不希望显示详细的开发者异常页面  
                // app.UseDeveloperExceptionPage();   
                app.UseExceptionHandler("/Error");
                // HSTS中间件应该在HTTPS重定向中间件之前  
                app.UseHsts();
            }

            // 启用HTTPS重定向  
            app.UseHttpsRedirection();

            // 静态文件应该在路由中间件之前，这样它们就可以被直接服务，而无需进入路由系统  
            app.UseStaticFiles();

            // 配置路由系统  
            app.UseRouting();

            // 配置授权中间件  
            app.UseAuthorization();

            // 映射控制器动作  
            app.MapControllers();

            // 映射Razor Pages  
            app.MapRazorPages();

            // 如果需要，可以在这里添加其他中间件  
        }
    }
}
