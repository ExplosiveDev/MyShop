
using DataAccess;
using DataAccess.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using MyShop.Interfaces;
using MyShop.Services;
using System.Numerics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("ShopDBcontext") ?? throw new InvalidOperationException("Connection string 'ShopMVCConnection' not found.");

builder.Services.AddDbContext<ShopDBcontext>(options => options.UseSqlServer(connection));

//add Repository for all entities
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


//Dependences Injection Remote Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
