using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.DTO;
using ProjetoMVC.Models;
using ProjetoMVC.ModelsEF;
using System.Diagnostics;
using System.Reflection;

namespace ProjetoMVC.Controllers
{
    public class EquipesController : Controller
    {
        private readonly ILogger<EquipesController> _logger;


        public EquipesController(ILogger<EquipesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(template:"")]
        public async Task<IActionResult> EquipesAsync(int pIdEquipe)
        {
            var buscaEquipe = new EquipesModel();
            using var connection = new SqlConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
            connection.Open();
            var cmd = connection.CreateCommand();

            cmd.CommandText = $"SELECT     " +
                $"A.IdEquipe,    " +
                $"NomeEquipe,    " +
                $"ModeloCarro,    " +
                $"FabricanteMotor,    " +
                $"NomeChefe,    " +
                $"MAX(CASE WHEN PilotoNum = 1 THEN NomePiloto ELSE NULL END) AS NomePiloto1,    " +
                $"MAX(CASE WHEN PilotoNum = 1 THEN NacionalidadePiloto ELSE NULL END) AS NacionalidadePiloto1,    " +
                $"MAX(CASE WHEN PilotoNum = 2 THEN NomePiloto ELSE NULL END) AS NomePiloto2,    " +
                $"MAX(CASE WHEN PilotoNum = 2 THEN NacionalidadePiloto ELSE NULL END) AS NacionalidadePiloto2,   " +
                $" QtdGrandesPremios,    " +
                $"QtdTitulosConstrutores,    " +
                $"QtdTitulosPilotos,    " +
                $"QtdVitorias,    " +
                $"QtdPodios,    " +
                $"QtdPolePosition,    " +
                $"QtdVoltasRapidasFROM     " +
                $"Formula1.dbo.Equipes AS A    " +
                $"INNER JOIN Formula1.dbo.Carros AS B ON A.IdEquipe = B.IdEquipe    " +
                $"INNER JOIN Formula1.dbo.Chefes AS C ON A.IdEquipe = C.IdEquipe    " +
                $"INNER JOIN         " +
                $"(SELECT             " +
                    $"IdEquipe,            " +
                    $"NomePiloto,            " +
                    $"NacionalidadePiloto,            " +
                    $"ROW_NUMBER() OVER (PARTITION BY IdEquipe ORDER BY NomePiloto) AS PilotoNum         " +
                    $"FROM             " +
                        $"Formula1.dbo.Pilotos        ) AS D ON A.IdEquipe = D.IdEquipe    " +
               $"INNER JOIN Formula1.dbo.Conquistas AS E ON A.IdEquipe = E.IdEquipeWHERE     A.IdEquipe = '{pIdEquipe}' " +
               $"GROUP BY    " +
                    $"A.IdEquipe,    " +
                    $"NomeEquipe,    " +
                    $"ModeloCarro,    " +
                    $"FabricanteMotor,    " +
                    $"NomeChefe,    " +
                    $"QtdGrandesPremios,    " +
                    $"QtdTitulosConstrutores,    " +
                    $"QtdTitulosPilotos,    " +
                    $"QtdVitorias,    " +
                    $"QtdPodios,    " +
                    $"QtdPolePosition,    " +
                    $"QtdVoltasRapidas";
            var dbContext = new Formula1Context();
            var model = new EquipeModelo();
            var equipeModel = await dbContext
                .Equipes
                .Include(e => e.Carros)
                .Include(e => e.Chefes)
                .Include(e => e.Pilotos)
                .Include(e => e.Conquista)
                .SingleOrDefaultAsync(e => e.IdEquipe.Equals(pIdEquipe));
            if (equipeModel != null)
            {
                model.Equipe = equipeModel;
                model.Carros = equipeModel?.Carros.First();
                model.Chefes = equipeModel?.Chefes.First();
                model.Conquistas = equipeModel?.Conquista.First();

                // Verifique se as propriedades Pilotos estão inicializadas
                if (model.Pilotos == null)
                {
                    model.Pilotos = new List<Piloto>();
                }

                if (equipeModel.Pilotos != null)
                {
                    foreach (var piloto in equipeModel.Pilotos)
                    {
                        model.Pilotos.Add(piloto);
                    }
                }
            }

            return View(model);


            /*
                             model.Equipe.IdEquipe = equipeModel.IdEquipe;
                model.Equipe.NomeEquipe = equipeModel.NomeEquipe;
            var buscaEquipe = new EquipesModel();
            using var connection = new SqlConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = $"Select * from Equipes where EquipeID = '{IdEquipe}'";
            var dataReader = cmd.ExecuteReader();

            
            if (dataReader.Read())
            {
                buscaEquipe.EquipeID             = dataReader["EquipeID"].ToString();
                buscaEquipe.NomeEquipe           = dataReader["NomeEquipe"].ToString();
                buscaEquipe.Construtor           = dataReader["Construtor"].ToString();
                buscaEquipe.NomeChefe            = dataReader["NomeChefe"].ToString();
                buscaEquipe.NomePiloto1          = dataReader["NomePiloto1"].ToString();
                buscaEquipe.NacionalidadePiloto1 = dataReader["NacionalidadePiloto1"].ToString();
                buscaEquipe.NomePiloto2          = dataReader["NomePiloto2"].ToString();
                buscaEquipe.NacionalidadePiloto2 = dataReader["NacionalidadePiloto2"].ToString();
                buscaEquipe.Modelo               = dataReader["Modelo"].ToString();
                buscaEquipe.Motor                = dataReader["Motor"].ToString();
                buscaEquipe.GrandesPremios       = dataReader["QtdGrandesPremios"].ToString();
                buscaEquipe.TitulosConstrutores  = dataReader["QtdTitulosConstrutores"].ToString();
                buscaEquipe.TitulosPilotos       = dataReader["QtdTitulosPilotos"].ToString();
                buscaEquipe.Vitorias             = dataReader["QtdVitorias"].ToString();
                buscaEquipe.Podios               = dataReader["QtdPodios"].ToString();
                buscaEquipe.PolePosition         = dataReader["QtdPolePosition"].ToString();
                buscaEquipe.VoltasRapidas        = dataReader["QtdVoltasRapidas"].ToString();
            }
            */
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
