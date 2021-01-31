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
        private string bottoken;
        private string chatid;
        private TelegramBotClient botClient;
        public Telegram(string bottoken, string chatid)
        {
            this.bottoken = bottoken;
            this.chatid = chatid;
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            botClient = new TelegramBotClient(bottoken);

        }

        public async Task TelegramTextAsync(string tg_text)
        {
            
            
            var me = await botClient.GetMeAsync();
            await botClient.SendTextMessageAsync(
                 chatId: this.chatid,
                 text: tg_text
               );
        }

        public async Task TelegramImgAsync(string tg_text, string imgUrl)
        {
            var me = await botClient.GetMeAsync();
            await botClient.SendPhotoAsync(
                 chatId: this.chatid,
                 photo: imgUrl,
                 caption: tg_text
               );

        }


    }
}

