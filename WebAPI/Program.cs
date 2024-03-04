using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AppDb"));

//builder.Services.AddIdentityCore<IdentityUser>()
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddApiEndpoints();

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<MyDbContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));

builder.Services.AddScoped<IEmployee, EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.MapIdentityApi<IdentityUser>();

app.UseAuthorization();

app.MapControllers();



app.Run();

//class AppDbContext : IdentityDbContext<IdentityUser>
//{
//    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
//}
