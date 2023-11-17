namespace Learn2MVC.Data
{
    using Learn2MVC.Entity;
    using Learn2MVC.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class AppDbContext : DbContext
    {
        public DbSet<Folder> Folders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }

}
