using Learn2MVC.Data;
using Learn2MVC.Entity;
using Learn2MVC.Models;
using Learn2MVC.Repositories;
using Learn2MVC.Repositories.Abstractions;
using Learn2MVC.Services;
using Learn2MVC.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Learn2MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IFolderRepository, FolderRepository>();
            builder.Services.AddScoped<IFolderService, FolderService>();
            builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDatabase"));
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();


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

            
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
                var folderService = serviceProvider.GetRequiredService<IFolderService>();
                var filePath = "Structure.txt";
                var exportFilePath = "ImportedStructure.txt";
                folderService.ImportFromTextFile(filePath);
                folderService.ExportToTextFile(exportFilePath);
                folderService.ImportFromTextFile(exportFilePath);
            }

            app.Run();
        }

    }
}
