using Autofac;
using Autofac.Extensions.DependencyInjection;
using Demo1;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// 配置Autofac作为依赖注入容器  
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// 添加你的服务配置（如果需要的话）  
// 例如：  
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

//builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddTransient<IUserService, UserService>();

// 注册Autofac模块  
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new ApiModule());
});

// 构建应用程序  
var app = builder.Build();

// 配置请求管道  
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.  
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// 运行应用程序  
app.Run();