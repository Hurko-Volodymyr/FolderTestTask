using Learn2MVC.Data;
using Learn2MVC.Models;
using Learn2MVC.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Learn2MVC.Repositories
{
    public class FolderRepository : IFolderRepository
    {
        private readonly AppDbContext _dbContext;

        public FolderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Folder> GetAllFolders()
        {
            return _dbContext.Folders.ToList();
        }

        public Folder? GetFolderById(int id)
        {
            var folder = _dbContext.Folders.FirstOrDefault(f => f.Id == id);

            if (folder != null)
            {
                folder.Children = _dbContext.Folders.Where(f => f.ParentId == folder.Id).ToList();
            }

            return folder;
        }

        public void AddFolder(Folder folder)
        {
            _dbContext.Folders.Add(folder);
            _dbContext.SaveChanges();
        }

        public void ImportFromTextFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var folder = ParseFolderFromLine(line);

                var existingFolder = _dbContext.Folders
                    .FirstOrDefault(f => f.Name == folder.Name && f.ParentId == folder.ParentId);

                if (existingFolder == null)
                {
                    _dbContext.Folders.Add(folder);
                }
            }
                _dbContext.SaveChanges();
        }

        public void ExportToTextFile(string filePath)
        {
            var folders = _dbContext.Folders.ToList();

            using (var writer = new StreamWriter(filePath))
            {
                foreach (var folder in folders)
                {
                    writer.WriteLine($"{folder.Id},{folder.Name},{folder.ParentId}");
                }
            }
        }

        private Folder ParseFolderFromLine(string line)
        {
            var parts = line.Split(',');

            if (parts.Length >= 3 && int.TryParse(parts[0], out var id) && int.TryParse(parts[2], out var parentId))
            {
                return new Folder
                {
                    Id = id,
                    Name = parts[1],
                    ParentId = parentId
                };
            }
            throw new FormatException("Incorrect format");
        }



    }
}
