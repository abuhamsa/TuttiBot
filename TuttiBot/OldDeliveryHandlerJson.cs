using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TuttiBot
{
    internal class OldDeliveryHandlerJson

    {
        private string confFile_path = "C:\\Users\\reberja\\Documents\\tuttibot\\searches.json";
        // Muss noch aus Datei geladen werden (filepath)
        public List<SearchIds> loadAllNotifiedIds(string file_path)
        {
            string jsonstring = File.ReadAllText(file_path);
            if (jsonstring == "")
            {

                return null;
            }

            List<SearchIds> allNotfiedSearches = JsonConvert.DeserializeObject<List<SearchIds>>(jsonstring);
            return allNotfiedSearches;
        }

        public List<int> getNotifiedIdsFromOneSearch (List<SearchIds> allNotfiedSearches, string searchTerm)
        {
             foreach (SearchIds searchIds in allNotfiedSearches)
            {
                if (searchIds.searchTerm.Equals(searchTerm))
                {
                    return searchIds.ids;
                }

            }

            return null;

        }

      
        // Muss noch in Datei gespeichert werden
        public void addNewNotifiedIds (string search,List <int> notified_ids,string file_path)
        {
            List<SearchIds> nullSearchIds = new List<SearchIds>();
            List<SearchIds> oldSearchIds = this.loadAllNotifiedIds(file_path);
            SearchIds newSearchIds = new SearchIds(search, notified_ids);

            if (oldSearchIds == null)
            {

                nullSearchIds.Add(newSearchIds);
                string jsonstring = JsonConvert.SerializeObject(nullSearchIds);
                File.WriteAllText(file_path, jsonstring);
            }
            else
            {

               // oldSearchIds.Add(newSearchIds);

                foreach (SearchIds searchIds in oldSearchIds)
                {
                    if (searchIds.searchTerm.Equals(newSearchIds.searchTerm)){
                        searchIds.ids = newSearchIds.ids;
                    }
                }

                string jsonstring = JsonConvert.SerializeObject(oldSearchIds);
                File.WriteAllText(file_path, jsonstring);
            }
          

        }

        

        public void sendNewOffersPushover(List<Offer> offers, string searchTerm)
        {
            Pushover pushover = new Pushover("uoGz5xaAPxZQFGDJwPhEF3vJF6eeYG", "ae965hsnhmamdo12wcpmxw75fto72a");
            List<int> notified_ids = null;
            List<SearchIds> allNotifiedIds = this.loadAllNotifiedIds(this.confFile_path);
            if (allNotifiedIds == null)
            {
                notified_ids = null;
                List<int> currentSearch_ids = new List<int>();
                foreach (Offer offer in offers)
                {
                    currentSearch_ids.Add(Int32.Parse(offer.offer_id));
                }

                List<int> unnotified_ids = currentSearch_ids;


                foreach (Offer offer in offers)
                {
                    if (unnotified_ids.Contains(Int32.Parse(offer.offer_id)))
                    {

                        pushover.sendText(offer.title, offer.ToString());
                    }
                }

                this.addNewNotifiedIds(searchTerm, unnotified_ids, this.confFile_path);
            }
            else
            {
                notified_ids = this.getNotifiedIdsFromOneSearch(allNotifiedIds, searchTerm);
                List<int> currentSearch_ids = new List<int>();
                foreach (Offer offer in offers)
                {
                    currentSearch_ids.Add(Int32.Parse(offer.offer_id));
                }

                List<int> unnotified_ids = currentSearch_ids.Except(notified_ids).ToList();


                foreach (Offer offer in offers)
                {
                    if (unnotified_ids.Contains(Int32.Parse(offer.offer_id)))
                    {

                        pushover.sendText(offer.title, offer.ToString());
                    }
                }

                this.addNewNotifiedIds(searchTerm, unnotified_ids, this.confFile_path);
            }

            


        }



    }
}