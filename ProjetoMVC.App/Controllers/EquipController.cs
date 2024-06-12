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
        private readonly IRepository _repository = repository;
        private readonly IEquipServices _equipServices = equipServices;


        [HttpGet]
        public async Task<IActionResult> Home()
        {

            var equips = await _equipServices.GetAllEquipsAsync();
            return View(equips);

 
        }

        [HttpGet("/equipe/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            var details = await _equipServices.GetEquipBySlugAsync(slug);
            
            if (details == null)
            {
                return View("NotFound");
            }

            return View(new DetailsModel
            {
                SelectedEquip = details,
                Equips = await _equipServices.GetAllEquipsAsync()
            });
        }
        
    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
