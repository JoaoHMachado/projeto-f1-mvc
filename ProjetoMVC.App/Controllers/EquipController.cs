using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.App.DTO;
using ProjetoMVC.App.Repository;
using ProjetoMVC.App.Services;

namespace ProjetoMVC.App.Controllers
{
    
    public class EquipController(ILogger<EquipController> logger, IRepository repository, IEquipServices equipServices) : Controller
    {
        private readonly ILogger<EquipController> _logger = logger;

        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Home()
        {
            var equips = await equipServices.GetAllEquipsAsync();
            return View(equips);
        }

        
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [HttpGet("/equipe/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            var details = await equipServices.GetEquipBySlugAsync(slug);
            if (details == null)
                return View("NotFound");

            return View(new DetailsModel
            {
                SelectedEquip = details,
                Equips = await equipServices.GetAllEquipsAsync()
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
