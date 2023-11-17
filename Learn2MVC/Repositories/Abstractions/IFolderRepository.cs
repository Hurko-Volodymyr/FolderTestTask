using Learn2MVC.Models;

namespace Learn2MVC.Repositories.Abstractions
{
    public interface IFolderRepository
    {
            IEnumerable<Folder> GetAllFolders();
            Folder? GetFolderById(int id);
            void AddFolder(Folder folder);
            void ImportFromTextFile(string filePath);
            void ExportToTextFile(string filePath);    

    }
}
