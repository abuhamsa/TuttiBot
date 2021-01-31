using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;


namespace TuttiBot
{
    public class Telegram
    {
        
        public async Task TelegramTextAsync(string tg_text)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            TelegramBotClient botClient;
            botClient = new TelegramBotClient("1628795996:AAEaFcRaZmV1oCGBN_b9LkqFPckicoWJUzA");
            var me = await botClient.GetMeAsync();
            await botClient.SendTextMessageAsync(
                 chatId: -586353124,
                 text: tg_text
               );
        }

        public async Task TelegramImgAsync(string tg_text, string imgUrl)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            TelegramBotClient botClient;
            botClient = new TelegramBotClient("1628795996:AAEaFcRaZmV1oCGBN_b9LkqFPckicoWJUzA");
            var me = await botClient.GetMeAsync();
            await botClient.SendPhotoAsync(
                 chatId: -586353124,
                 photo: imgUrl,
                 caption: tg_text
               );

        }


    }
}

