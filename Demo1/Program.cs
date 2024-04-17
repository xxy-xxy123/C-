using Autofac;
using Autofac.Extensions.DependencyInjection;
using Demo1;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// ����Autofac��Ϊ����ע������  
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// �����ķ������ã������Ҫ�Ļ���  
// ���磺  
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

//builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddTransient<IUserService, UserService>();

// ע��Autofacģ��  
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new ApiModule());
});

// ����Ӧ�ó���  
var app = builder.Build();

// ��������ܵ�  
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

// ����Ӧ�ó���  
app.Run();