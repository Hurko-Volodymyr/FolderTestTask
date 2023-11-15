using Learn2MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Learn2MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var folders = new List<Folder>() {
                new Folder() { Id = 1, Name = "Creating Digital Images", ParentId = 0 },
                new Folder() { Id = 2, Name = "Resources", ParentId = 1},
                new Folder() { Id = 3, Name = "Evidence", ParentId = 1 },
                new Folder() { Id = 4, Name = "Graphic Products", ParentId = 1},
                new Folder() { Id = 5, Name = "Primary Sources", ParentId = 2},
                new Folder() { Id = 6, Name = "Secondary Sources", ParentId = 2},
                new Folder() { Id = 7, Name = "Proces", ParentId = 4},
                new Folder() { Id = 8, Name = "Final Product", ParentId = 4},

            };

            return View(folders);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

       

        public IActionResult Privacy()
        {
            return View();
        }



        public IActionResult FolderDetails(int id)
        {
            var folderDetails = GetFolderDetailsById(id);

            if (folderDetails == null)
            {
                return NotFound(); 
            }

            return View(folderDetails);
        }

        private Folder GetFolderDetailsById(int id)
        {
            var folders = new List<Folder>
            {
                new Folder() { Id = 1, Name = "Creating Digital Images", ParentId = 0 },
                new Folder() { Id = 2, Name = "Resources", ParentId = 1},
                new Folder() { Id = 3, Name = "Evidence", ParentId = 1 },
                new Folder() { Id = 4, Name = "Graphic Products", ParentId = 1},
                new Folder() { Id = 5, Name = "Primary Sources", ParentId = 2},
                new Folder() { Id = 6, Name = "Secondary Sources", ParentId = 2},
                new Folder() { Id = 7, Name = "Proces", ParentId = 4},
                new Folder() { Id = 8, Name = "Final Product", ParentId = 4},
            };

            var folder = folders.FirstOrDefault(f => f.Id == id);

            if (folder != null)
            {
                folder.Children = folders.Where(f => f.ParentId == folder.Id).ToList();
            }

            return folder;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

