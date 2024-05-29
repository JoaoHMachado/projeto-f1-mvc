using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;
using ProjetoMVC.Classes;
using System.Collections.Generic;

namespace ProjetoMVC.Classes
{
    public class GetWikipedia
    {
        public async Task<string> GetDadosWikipedia()
        {
            try
            {
                /*
                var Status = "Realizando o scraping...";
                Table = [];
                */
                
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
                Console.WriteLine(countLinks);
                foreach (var link in links)
                {
                    countLinks++;
                    if (countLinks > links.Count()) break;
                    var chegueiPrimeiroDado = false;
                    var chegueiUltimoDado = false;
                    Console.WriteLine(link);
                    HttpClient httpClient = new HttpClient();
                    var html = new HtmlDocument();
                    var textResponse = await httpClient.GetStringAsync(link);
                    var list = new List<string>();
                    html.LoadHtml(textResponse);

                    var document = html.DocumentNode;

                    var trs = document.QuerySelectorAll("table.infobox tr");
                    Console.WriteLine(trs);
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
                                var updateEquipes = new UpdateEquipes();
                                updateEquipes.AtualizaDadosEquipes(countLinks, list);
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
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }

        }
    }

   
}
