using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TuttiBot
{
    class Telegram
    {
        static ITelegramBotClient botClient;
        public async Task TelegramTestAsync()
        {
            botClient = new TelegramBotClient("1628795996:AAEaFcRaZmV1oCGBN_b9LkqFPckicoWJUzA");
            //await botClient.SendTextMessageAsync("Test");
        }


    }
}

