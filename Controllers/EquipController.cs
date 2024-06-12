using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.DTO;
using ProjetoMVC.Models;
using ProjetoMVC.ModelsEF;
using System.Diagnostics;
using System.Reflection;
using ProjetoMVC.Repository;
using ProjetoMVC.Services;

namespace ProjetoMVC.Controllers
{
    
    public class EquipController(ILogger<EquipController> logger, IRepository repository, IEquipServices equipServices) : Controller
    {
        private readonly ILogger<EquipController> _logger = logger;
        private readonly IRepository _repository = repository;
        private readonly IEquipServices _equipServices = equipServices;


        [HttpGet(template:"")]
        public async Task<IActionResult> EquipesAsync(int pIdEquipe)
        {
              
      
            return View();

 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
