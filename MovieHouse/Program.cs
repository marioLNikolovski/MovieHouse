using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieHouse.Configurations;
using MovieHouse.Extensions;
using MovieHouse.Infrastructure.Data;
using MovieHouse.Infrastructure.Data.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationDbContexts(builder.Configuration);
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();



builder.Services.AddControllersWithViews();

builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();


using var scope = app.Services.CreateScope();

var adminUserSeedConfiguration = scope.ServiceProvider.GetService<IOptions<AdminUserSeedConfiguration>>();

await ApplicationDbContextExtensions.EnsureSeeded(adminUserSeedConfiguration.Value, scope.ServiceProvider);



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Identity",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
//app.MapControllerRoute(
//    name: "Administration",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
//app.MapAreaControllerRoute(
//    name: "Administration",
//    areaName: "Administration",
//    pattern: "Administration/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
