using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoMVC.Models
{
    public class GetWikipedia
    {
        public string GetDadosWikipedia(int Id)
        {
            try
            {
                /*
                var Status = "Realizando o scraping...";
                Table = [];
                */

                var html = new HtmlDocument();
                var textResponse = $"https://pt.wikipedia.org/wiki/Red_Bull_Racing"; /*await _client.GetStringAssync(_basePath);*/
                var urls = new List<string>();
                html.LoadHtml(textResponse);

                var document = html.DocumentNode;

                var trs = document.QuerySelectorAll("tr");
                Console.WriteLine(trs);
                foreach (var tr in trs)
                {
                    //var row = new Row();

                    var link = tr.QuerySelectorAll("td > a");
                    if (link?.Count() == 0) continue;

                    var href = link.First().GetAttributes("href").FirstOrDefault()?.Value;

                    if (string.IsNullOrEmpty(href) || !href.EndsWith("")) continue;
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
