using RailwayStation.Business.IoC;
using RailwayStation.DataAccess.Database;
using RailwayStation.DataAccess.IoC;
using RailwayStation.Entity.Modals;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RailwayStationContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<RailwayStationContext>();

builder.Services.AddDataAccessServices();
builder.Services.AddBusinessServices();


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
