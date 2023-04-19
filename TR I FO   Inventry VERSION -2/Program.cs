using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using TR_I_FO___Inventry_VERSION__2.Models;
using TR_I_FO___Inventry_VERSION__2.Areas.Identity.Data;
using System.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<context>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ContentCreatorConnection")));

builder.Services.AddDbContext<loginContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("loginContextConnection")));


builder.Services.AddDefaultIdentity<usercontext>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<loginContext>();


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
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
