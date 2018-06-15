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
        public List<SearchIdsAndTerms> loadAllNotifiedIds(string file_path)
        {
            string jsonstring = File.ReadAllText(file_path);
            if (jsonstring == "")
            {

                return null;
            }

            List<SearchIdsAndTerms> allNotfiedSearches = JsonConvert.DeserializeObject<List<SearchIdsAndTerms>>(jsonstring);
            return allNotfiedSearches;
        }

        public List<int> getNotifiedIdsFromOneSearch (List<SearchIdsAndTerms> allNotfiedSearches, string searchTerm)
        {
             foreach (SearchIdsAndTerms searchIds in allNotfiedSearches)
            {
                if (searchIds.searchTerm.Equals(searchTerm))
                {
                    return searchIds.ids;
                }

            }

            return null;

        }

      
        // Muss noch in Datei gespeichert werden
        public Boolean addNewNotifiedIds (string search,List <int> notified_ids,string file_path)
        {
            if (notified_ids.Count == 0) { return false; }
            List<SearchIdsAndTerms> nullSearchIds = new List<SearchIdsAndTerms>();
            List<SearchIdsAndTerms> oldSearchIds = this.loadAllNotifiedIds(file_path);
            SearchIdsAndTerms newSearchIds = new SearchIdsAndTerms(search, notified_ids);

            if (oldSearchIds == null)
            {

                nullSearchIds.Add(newSearchIds);
                string jsonstring = JsonConvert.SerializeObject(nullSearchIds);
                File.WriteAllText(file_path, jsonstring);
                return true;
            }
            else
            {

                oldSearchIds.Add(newSearchIds);

                foreach (SearchIdsAndTerms searchIds in oldSearchIds)
                {
                    if (searchIds.searchTerm.Equals(newSearchIds.searchTerm)){
                        searchIds.ids = newSearchIds.ids;
                    }
                }

                string jsonstring = JsonConvert.SerializeObject(oldSearchIds);
                File.WriteAllText(file_path, jsonstring);
                return true;
            }
          

        }

        

        public void sendNewOffersPushover(List<Offer> offers, string searchTerm)
        {
            Pushover pushover = new Pushover("uoGz5xaAPxZQFGDJwPhEF3vJF6eeYG", "ae965hsnhmamdo12wcpmxw75fto72a");
            List<int> notified_ids = null;
            List<SearchIdsAndTerms> allNotifiedIds = this.loadAllNotifiedIds(this.confFile_path);
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

                        pushover.pushText(offer.ToString());
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

                List<int> unnotified_ids = new List<int>();
                if (notified_ids == null)
                {
                    unnotified_ids = currentSearch_ids;
                }
                else
                {
                    unnotified_ids = currentSearch_ids.Except(notified_ids).ToList();
                }
                

                
                foreach (Offer offer in offers)
                {
                    if (unnotified_ids.Contains(Int32.Parse(offer.offer_id)))
                    {

                        pushover.pushText(offer.ToString());
                    }
                }

                this.addNewNotifiedIds(searchTerm, unnotified_ids, this.confFile_path);
            }

            


        }



    }
}