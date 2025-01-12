using Microsoft.EntityFrameworkCore;
using TiErp.Infrastructure.Persistence;
using TiErp.Infrastructure.Extensions;
using TiErp.Application.Extensions;
using TiErp.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using TiErp.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddRazorPages();


var app = builder.Build();

var scope = app.Services.CreateScope();

using (var s = app.Services.CreateScope())
{
    var roleManager = s.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    await RoleSeeder.Seed(roleManager);
}



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


app.MapRazorPages();

app.Run();
