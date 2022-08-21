using AOE_Scraper;
using System.Configuration;

string? path = ConfigurationManager.AppSettings.Get("Path");
string? urlAoE3 = ConfigurationManager.AppSettings.Get("AOE3");
string ? urlAoE2 = ConfigurationManager.AppSettings.Get("AOE2");

List<string> titulosAoE3 = NewsMethods.GetLast3News(urlAoE3);
if (path is not null)
{
    bool newUpdateAoE3 = NewsMethods.CheckUpdatesWithFile(titulosAoE3, path);
    NewsMethods.SaveNewTitles(titulosAoE3, path);
    if (newUpdateAoE3)
        await TelegramMessage.SendTelegramMessageAsync();
}


List<string> titulosAoE2 = NewsMethods.GetLast3News(urlAoE2);
if (path is not null)
{
    bool newUpdateAoE2 = NewsMethods.CheckUpdatesWithFile(titulosAoE2, path);
    NewsMethods.SaveNewTitles(titulosAoE2, path);
    if (newUpdateAoE2)
        await TelegramMessage.SendTelegramMessageAsync();
}




