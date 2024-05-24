using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProjetoMVC.Models;
using System.Diagnostics;
using System.Reflection;

namespace ProjetoMVC.Controllers
{
    public class EquipesController : Controller
    {
        private readonly ILogger<EquipesController> _logger;

        public EquipesModel equipesModel { get; set; }
        public EquipesController(ILogger<EquipesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(template:"")]
        public IActionResult Equipes(int IdEquipe)
        {
            //IdEquipe = 1;
            var buscaEquipe = new EquipesModel();
            using var connection = new SqlConnection("Data Source=Note-JP;Initial Catalog=Formula1;User ID=sa;Password=toppen;Trust Server Certificate=True");
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = $"Select * from Equipes where EquipeID = '{IdEquipe}'";
            var dataReader = cmd.ExecuteReader();

            if (dataReader.Read())
            {
                buscaEquipe.EquipeID =  dataReader["EquipeID"].ToString();
                buscaEquipe.NomeEquipe = dataReader["NomeEquipe"].ToString();
                buscaEquipe.Construtor = dataReader["Construtor"].ToString();
                buscaEquipe.NomeChefe = dataReader["NomeChefe"].ToString();
                buscaEquipe.NomePiloto1 = dataReader["NomePiloto1"].ToString();
                buscaEquipe.NacionalidadePiloto1 = dataReader["NacionalidadePiloto1"].ToString();
                buscaEquipe.NomePiloto2 = dataReader["NomePiloto2"].ToString();
                buscaEquipe.NacionalidadePiloto2 = dataReader["NacionalidadePiloto2"].ToString();
                buscaEquipe.Modelo = dataReader["Modelo"].ToString();
                buscaEquipe.Motor = dataReader["Motor"].ToString();

            }
            return View(buscaEquipe);
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
