using AdminApplication.Models;
using Microsoft.EntityFrameworkCore;
using AdminApplication.Repository;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreContext>(
    option => option.UseSqlServer("server=DESKTOP-O14444V\\SQLEXPRESS;user Id = sa; password = 1;database=Store")

);
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();



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
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
