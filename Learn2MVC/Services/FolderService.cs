using Learn2MVC.Data;
using Learn2MVC.Entity;
using Learn2MVC.Models;
using Learn2MVC.Repositories;
using Learn2MVC.Repositories.Abstractions;
using Learn2MVC.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Learn2MVC.Services
{
    public class FolderService : IFolderService
    {
        private readonly IFolderRepository _repository;

        public FolderService(IFolderRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Folder> GetAllFolders()
        {
            return _repository.GetAllFolders();
        }

        public Folder? GetFolderDetailsById(int id)
        {
            return _repository.GetFolderById(id);
        }

        public void ImportFromTextFile(string filePath)
        {
            _repository.ImportFromTextFile(filePath);
        }

        public void ExportToTextFile(string filePath)
        {
            _repository.ExportToTextFile(filePath);
        }


    }
}
