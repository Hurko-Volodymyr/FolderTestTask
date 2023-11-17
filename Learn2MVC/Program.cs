using Learn2MVC.Data;
using Learn2MVC.Entity;
using Learn2MVC.Models;
using Learn2MVC.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Learn2MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IFolderService, FolderService>();
            builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDatabase"));
            builder.Services.AddControllersWithViews();


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
                if (!dbContext.Folders.Any())
                {

                    dbContext.Folders.AddRange(
                         new Folder() { Id = 1, Name = "Creating Digital Images", ParentId = 0 },
                         new Folder() { Id = 2, Name = "Resources", ParentId = 1 },
                         new Folder() { Id = 3, Name = "Evidence", ParentId = 1 },
                         new Folder() { Id = 4, Name = "Graphic Products", ParentId = 1 },
                         new Folder() { Id = 5, Name = "Primary Sources", ParentId = 2 },
                         new Folder() { Id = 6, Name = "Secondary Sources", ParentId = 2 },
                         new Folder() { Id = 7, Name = "Proces", ParentId = 4 },
                         new Folder() { Id = 8, Name = "Final Product", ParentId = 4 });

                    dbContext.SaveChanges();
                }
            }

            app.Run();
        }

    }
}
