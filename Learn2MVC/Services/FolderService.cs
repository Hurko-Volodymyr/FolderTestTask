using Learn2MVC.Data;
using Learn2MVC.Entity;
using Learn2MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn2MVC.Services
{
    public class FolderService : IFolderService
    {
        private readonly AppDbContext _dbContext;

        public FolderService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Folder> GetAllFolders()
        {
            return _dbContext.Folders.ToList();
        }

        public Folder? GetFolderDetailsById(int id)
        {
            var folder = _dbContext.Folders.FirstOrDefault(f => f.Id == id);

            if (folder != null)
            {
                folder.Children = _dbContext.Folders.Where(f => f.ParentId == folder.Id).ToList();
            }

            return folder;
        }

    }
}
