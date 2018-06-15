using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuttiBot
{
    class SearchIdsNotifyHandlerJson
    {
        private string confFile_path;

        public SearchIdsNotifyHandlerJson(string confFile_path)
        {
            this.confFile_path = confFile_path;
        }

        //GIVES YOU ALL IDS THAT ARE NOT IN THE CONFIGFILE
        public List<int> getUnnotifiedIds(List<Offer> offers)
        {
            List<int> currentSearchIds=new List<int>();
            foreach (Offer offer in offers)
            {
                currentSearchIds.Add(Int32.Parse(offer.offer_id));
            }

            string jsonstring = File.ReadAllText(this.confFile_path);
            List<int> alreadyNotifiedSearchIds = JsonConvert.DeserializeObject<List<int>>(jsonstring);

            List<int> newSearchIds = currentSearchIds.Except(alreadyNotifiedSearchIds).ToList();
            return newSearchIds;
        }

        //UPDATES THE CONFIGFILE WITH THE NEWLY NOTIFIED IDS
        public void updateAlreadyNotifiedIds (List<int> newSearchIds)
        {

            string jsonstring = File.ReadAllText(this.confFile_path);
            List<int> alreadyNotifiedSearchIds = JsonConvert.DeserializeObject<List<int>>(jsonstring);

            List<int> updatedAlreadyNotifiedSearchIds = new List<int>();
            updatedAlreadyNotifiedSearchIds.AddRange(alreadyNotifiedSearchIds);
            updatedAlreadyNotifiedSearchIds.AddRange(newSearchIds);

            string jsonstring1 = JsonConvert.SerializeObject(updatedAlreadyNotifiedSearchIds);
            File.WriteAllText(this.confFile_path, jsonstring1);

        }


        //USE THIS TO CREATE THE FIRST JSONFILE
        public void testSerialzie (List<Offer>offers)
        {
            List<int> saveIds = new List<int>();
            foreach (Offer offer in offers)
            {
                saveIds.Add(Int32.Parse(offer.offer_id));
            }

            string jsonstring = JsonConvert.SerializeObject(saveIds);
            File.WriteAllText(this.confFile_path, jsonstring);

        }

    }
}
