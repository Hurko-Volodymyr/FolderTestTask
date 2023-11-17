using Learn2MVC.Entity;
using Learn2MVC.Models;

namespace Learn2MVC.Services.Abstractions
{
    public interface IFolderService
    {
        IEnumerable<Folder> GetAllFolders();
        Folder? GetFolderDetailsById(int id);
        void ImportFromTextFile(string filePath);
        void ExportToTextFile(string filePath);
    }
}
