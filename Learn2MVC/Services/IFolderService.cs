using Learn2MVC.Entity;
using Learn2MVC.Models;

namespace Learn2MVC.Services
{
    public interface IFolderService
    {
        IEnumerable<Folder> GetAllFolders();
        Folder? GetFolderDetailsById(int id);
    }
}
