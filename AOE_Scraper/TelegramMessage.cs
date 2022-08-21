using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOE_Scraper
{
    public static class TelegramMessage
    {
        public static async Task<bool> SendTelegramMessageAsync()
        {
            string? apiKey = ConfigurationManager.AppSettings.Get("TelegramApi");
            string? chatId = ConfigurationManager.AppSettings.Get("ChatID");

            var myClient = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
            var response = await myClient.GetAsync("https://api.telegram.org/bot" + apiKey + "/sendMessage?chat_id=" + chatId + "&text=" + "Hay evento!");
            var streamResponse = await response.Content.ReadAsStreamAsync();
            
            return true;
        }
    }
}
