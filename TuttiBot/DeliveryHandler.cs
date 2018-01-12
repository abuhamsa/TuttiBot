using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TuttiBot
{
    internal class DeliveryHandler
    {


        public void load_search_data_json (string file_path)
        {

        }

        public void test_dump_json()
        {
            
        }

        public void dump_search_data_json (string search,List <int> notified_ids,string file_path)
        {
            

        }

        public List<int> getNotifiedIds (string search, string file_path)
        {
            List<int> notified_ids = new List<int>();
            return notified_ids;
        }
        

        public void sendNewOffersPushover(List<Offer> offers)
        {
            Pushover pushover = new Pushover("uoGz5xaAPxZQFGDJwPhEF3vJF6eeYG", "ae965hsnhmamdo12wcpmxw75fto72a");
            List<int> notified_ids = this.getNotifiedIds("blub","blo");

            List<int> complete_ids = new List<int>();
            foreach (Offer offer in offers)
            {
                complete_ids.Add(Int32.Parse(offer.offer_id));
            }

            List<int> unnotified_ids = complete_ids.Except(notified_ids).ToList();

            List<Offer> unnotified_offers = new List<Offer>();
            foreach (Offer offer in offers)
            {
                if (unnotified_ids.Contains(Int32.Parse(offer.offer_id))){

                    pushover.sendText(offer.title,offer.ToString());

                }
            }

            string search = "";
            string file_path = "";

            dump_search_data_json( search, unnotified_ids,  file_path);

        }



    }
}