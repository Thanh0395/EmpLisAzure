using Azure.Identity;
using Buoi03Core;
using Buoi03Core.Models;
using Buoi03Core.Repository;
using Buoi03Core.Respository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Connect to azure KeyVault
var KeyVaultUrl = new Uri(builder.Configuration.GetSection("KeyVaultURL").Value!);
var azureCredential = new DefaultAzureCredential();
builder.Configuration.AddAzureKeyVault(KeyVaultUrl, azureCredential);
var cs = builder.Configuration.GetSection("azuresql").Value;
Console.WriteLine(cs);
//Connect bang connectionString thông thường
builder.Services.AddDbContext<DatabaseConText>(options =>
    options.UseSqlServer(cs));


builder.Services.AddScoped<IEmployeeRepository, EmpRepoIml>();//Tiem su phu thuoc

builder.Services.AddSingleton<FileService>();
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
