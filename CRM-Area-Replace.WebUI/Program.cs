using CRM_Area_Replace.DAL.Concreate.EF.Context;
using CRM_Area_Replace.Entities.Concreate;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Identity manager servisi için


//Connection stringi kullanabilmek için
builder.Services.AddDbContext<CRMContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
});
builder.Services.AddDefaultIdentity<UserAccount>(options =>
{

}).AddEntityFrameworkStores<CRMContext>();

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
	name: "areas", 
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
