using System.Data;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using Microsoft.Data.SqlClient;

namespace ProjetoMVC.App.Workers
{
    public class WikipediaScrapper : BackgroundService
    {
        private void AtualizaDadosEquipes(int IdEquipe, List<string> list)
        {
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();

                using var cmd = new SqlCommand("SP_Update_DadosEquipesViaWikipedia", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Adicionar parâmetros
                cmd.Parameters.AddWithValue("@IdEquipe", IdEquipe);
                cmd.Parameters.AddWithValue("@GrandesPremios", list[0]);
                cmd.Parameters.AddWithValue("@TitulosConstrutores", list[1]);
                cmd.Parameters.AddWithValue("@TitulosPilotos", list[2]);
                cmd.Parameters.AddWithValue("@Vitorias", list[3]);
                cmd.Parameters.AddWithValue("@Podios", list[4]);
                cmd.Parameters.AddWithValue("@PolePosition", list[5]);
                cmd.Parameters.AddWithValue("@VoltasRapidas", list[6]);
                // Executar o comando
                cmd.ExecuteNonQuery(); 
            }
            catch (Exception ex)
            {
                // Logar o erro conforme necessário 
            }
        }
        
        private async Task GetDadosWikipedia()
        {
            try
            {
                
                var links = new List<string>
                {
                    $"https://pt.wikipedia.org/wiki/Red_Bull_Racing",
                    $"https://pt.wikipedia.org/wiki/Mercedes-Benz_na_F%C3%B3rmula_1",
                    $"https://pt.wikipedia.org/wiki/McLaren",
                    $"https://pt.wikipedia.org/wiki/RB_F1_Team",
                    $"https://pt.wikipedia.org/wiki/Sauber_Motorsport",
                    $"https://pt.wikipedia.org/wiki/Aston_Martin_na_F%C3%B3rmula_1",
                    $"https://pt.wikipedia.org/wiki/Haas_F1_Team",
                    $"https://pt.wikipedia.org/wiki/Alpine_F1_Team",
                    $"https://pt.wikipedia.org/wiki/Williams_Grand_Prix_Engineering",
                    $"https://pt.wikipedia.org/wiki/Scuderia_Ferrari"  
                };
                var countLinks = 0;
                foreach (var link in links)
                {
                    countLinks++;
                    if (countLinks > links.Count()) break;
                    var chegueiPrimeiroDado = false;
                    var chegueiUltimoDado = false;
                    HttpClient httpClient = new HttpClient();
                    var html = new HtmlDocument();
                    var textResponse = await httpClient.GetStringAsync(link);
                    var list = new List<string>();
                    html.LoadHtml(textResponse);

                    var document = html.DocumentNode;

                    var trs = document.QuerySelectorAll("table.infobox tr");
                    foreach (var tr in trs)
                    {
                        if (chegueiUltimoDado) break;
                        //var row = new Row();

                        var tds = tr.QuerySelectorAll("td");
                        if (tds?.Count() == 0) continue;
                        var tdCount = 0;
                        foreach (var td in tds)
                        {
                            tdCount++;
                            if (td.InnerText.Trim().ToLower() == "pontos")
                            {
                                chegueiUltimoDado = true;
                                //conexao com banco 
                                AtualizaDadosEquipes(countLinks, list);
                                break;
                            }

                            if (td.InnerText.Trim().ToLower() == "grandes prêmios")
                            {
                                chegueiPrimeiroDado = true;
                            }

                            if (!chegueiPrimeiroDado) break;

                            if(tdCount == 2)
                            {
                                list.Add(td.InnerText.Trim());
                            }
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await GetDadosWikipedia();
                await Task.Delay(60000 * 60 * 24, stoppingToken);
            }
        }
    }
}
