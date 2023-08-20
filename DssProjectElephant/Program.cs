using DssProjectElephant.Data;
using DssProjectElephant.Interfaces;
using DssProjectElephant.Models;
using DssProjectElephant.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IClubRepository, ClubRepository>();
        builder.Services.AddScoped<INewsRepository, NewsRepository>();
        builder.Services.AddDbContext<ApplicationDbContent>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        var app = builder.Build();

        if (args.Length == 1 && args[0].ToLower() == "seeddata")
        {
            //Seed.SeedUsersAndRolesAsync(app);
            Seed.SeedData(app);
        }

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "news",
            pattern: "News/{action}/{id?}",
            defaults: new { controller = "News", action = "Index" });

        app.MapControllerRoute(
            name: "clubEdit",
            pattern: "Club/Edit/{id}",
            defaults: new { controller = "Club", action = "Edit" });

        app.Run();
    }
}

