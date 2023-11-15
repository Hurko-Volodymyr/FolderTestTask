namespace Learn2MVC.Data
{
    using Learn2MVC.Entity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class AppDbContext : DbContext
    {
        public DbSet<FolderEntity> Folders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }

}
