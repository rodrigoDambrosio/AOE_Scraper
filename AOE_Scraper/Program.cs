using HtmlAgilityPack;
using ScrapySharp.Extensions;

List<string> titulos = new();
HtmlWeb web = new HtmlWeb();
HtmlDocument doc = web.Load("https://www.ageofempires.com/news/category/releases?game=aoeii");

foreach (var titulo in doc.DocumentNode.CssSelect(".post__title"))
{
    if (titulo.InnerHtml.Contains("Update") || titulo.InnerHtml.Contains("Event"))
        titulos.Add(titulo.InnerHtml);
}
// Add aoe3 web
// Make config file and telegram bot
// Send telegram msg