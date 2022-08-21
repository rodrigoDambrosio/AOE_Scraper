using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOE_Scraper
{
    public static class NewsMethods
    {
        public static List<string> GetLast3News(string link)
        {
            List<string> titulos = new();

            HtmlWeb web = new HtmlWeb();
            HtmlDocument docAge3 = web.Load(link);

            foreach (var titulo in docAge3.DocumentNode.CssSelect(".post__title").Take(3))
            {
                if (titulo.InnerHtml.Contains("Update") || titulo.InnerHtml.Contains("Event"))
                {
                    titulos.Add(titulo.InnerHtml);
                }

            }

            return titulos;
        }

        public static bool CheckUpdatesWithFile(List<string> titulos, string path)
        {
            if (File.Exists(path))
            {
                string ultima = File.ReadLines(path).First();

                if (ultima == titulos[0])
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
                
        }

        public static bool SaveNewTitles(List<string> titulos, string path)
        {
            if(File.Exists(path))
                File.Delete(path);
            File.AppendAllLines(path,titulos);
            return true;
        }
    }
}
