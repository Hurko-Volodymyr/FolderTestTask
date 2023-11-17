using Learn2MVC.Data;
using Learn2MVC.Models;
using Learn2MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Learn2MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFolderService _folderService;

        public HomeController(ILogger<HomeController> logger, IFolderService folderService)
        {
            _logger = logger;
            _folderService = folderService;
        }

        public IActionResult Index()
        {
            var folders = _folderService.GetAllFolders();
            return View(folders);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult FolderDetails(int id)
        {
            var folderDetails = _folderService.GetFolderDetailsById(id);

            if (folderDetails == null)
            {
                return NotFound();
            }

            return View(folderDetails);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}

