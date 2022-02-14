using Microsoft.EntityFrameworkCore;
using PassingInputAssignmentApp.Models;
using PassingInputAssignmentApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string conn = builder.Configuration.GetConnectionString("conn");
builder.Services.AddDbContext<ShopContext>(options =>
{
    options.UseSqlServer(conn);
});
//injecting the service
builder.Services.AddScoped<IRepo<int, Product>, ProductRepo>();

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
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
