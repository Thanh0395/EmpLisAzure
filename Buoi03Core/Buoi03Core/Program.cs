using Buoi03Core.Models;
using Buoi03Core.Repository;
using Buoi03Core.Respository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseConText>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectDb")));
builder.Services.AddScoped<IEmployeeRepository, EmpRepoIml>();//Tiem su phu thuoc

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
//pattern: "{controller=Home}/{action=Index}/{id?}");
pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
