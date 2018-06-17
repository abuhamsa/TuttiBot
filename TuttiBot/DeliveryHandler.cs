using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuttiBot
{
    class DeliveryHandler
    {
        private string provider;
        private Pushover pushover;

        public DeliveryHandler(string provider)
        {
            this.provider = provider;
            switch (provider)
            {
                case "Pushover":
                    //MAYBE CHANGE THIS SO NOT FOR EVERY MESSAGE A NEW OBJECT HAVE TO BE CREATED
                    this.pushover = new Pushover("uoGz5xaAPxZQFGDJwPhEF3vJF6eeYG", "ae965hsnhmamdo12wcpmxw75fto72a");
                    break;
                case "Telegram":
                    Console.WriteLine("Telegram is not yet implemented!");
                    break;
            }

        }

        public void sendTextOnly(Offer offer)
        {

            switch (provider)
            {
                case "Pushover":
                    pushover.pushText(offer.ToString());
                    break;
                case "Telegram":
                    Console.WriteLine("Telegram is not yet implemented!");
                    break;
            }

        }

        public async Task<bool> sendCompleteAsync(Offer offer)
        {
            
            switch (provider)
            {
                case "Pushover":
                    await pushover.pushImage(offer.ToString(), offer.thumb_url);
                    
                    break;
                   
                case "Telegram":
                    Console.WriteLine("Telegram is not yet implemented!");
                    break;
            }
            return true;
        }



    }



}
