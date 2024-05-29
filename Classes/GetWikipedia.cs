using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

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
                HttpClient httpClient = new HttpClient();
                var html = new HtmlDocument();
                var textResponse = await httpClient.GetStringAsync($"https://pt.wikipedia.org/wiki/Red_Bull_Racing");
                var urls = new List<string>();
                html.LoadHtml(textResponse);

                var document = html.DocumentNode;

                var trs = document.QuerySelectorAll("table.infobox tr");
                Console.WriteLine(trs);
                foreach (var tr in trs)
                {
                    //var row = new Row();

                    var link = tr.QuerySelectorAll("td");
                    if (link?.Count() == 0) continue;
                    
                    var href = link.First().GetAttributes("href").FirstOrDefault()?.Value;

                    if (href.StartsWith("Grandes Prêmios") || !href.EndsWith("")) continue;
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
