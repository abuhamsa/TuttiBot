using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TuttiBot
{
    class DeliveryHandler
    {
        private string provider;
        private Pushover pushover;
        private Telegram telegram;

        public DeliveryHandler(string provider)
        {
            this.provider = provider;
            switch (provider)
            {
                case "Pushover":
                    //MAYBE CHANGE THIS SO NOT FOR EVERY MESSAGE A NEW OBJECT HAVE TO BE CREATED.
                    this.pushover = new Pushover(ConfigurationManager.AppSettings["userkey"], ConfigurationManager.AppSettings["applicationkey"]);
                    break;
                case "Telegram":
                    this.telegram = new Telegram();
                    break;
            }

        }

        public async void sendTextOnly(Offer offer)
        {

            switch (provider)
            {
                case "Pushover":
                    pushover.pushText(offer.ToString());
                    break;
                case "Telegram":
                    await telegram.TelegramTextAsync(offer.ToString());
                    break;
            }

        }

        public async Task<bool> sendCompleteAsync(Offer offer)
        {
            
            switch (provider)
            {
                case "Pushover":
                    if (offer.thumb_url == "https://c.tutti.ch/gallery/")
                    {
                        pushover.pushText(offer.ToString());
                    }
                    else
                    {
                        await pushover.pushImage(offer.ToString(), offer.thumb_url);
                    }
                    
                    break;
                   
                case "Telegram":
                    if (offer.thumb_url == "https://c.tutti.ch/gallery/")
                    {
                        await telegram.TelegramTextAsync(offer.ToString());
                        await Task.Delay(5000);
                    }
                    else
                        await telegram.TelegramImgAsync(offer.ToString(),offer.thumb_url);
                        await Task.Delay(5000);
                    break;
            }
            return true;
        }



    }



}
