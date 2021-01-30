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
        public List<long> getUnnotifiedIds(List<Offer> offers)
        {
            List<long> currentSearchIds=new List<long>();
            foreach (Offer offer in offers)
            {
                currentSearchIds.Add(long.Parse(offer.offer_id));
            }

            string jsonstring = File.ReadAllText(this.confFile_path);

            if (jsonstring != "")
            {
                List<long> alreadyNotifiedSearchIds = JsonConvert.DeserializeObject<List<long>>(jsonstring);

                List<long> newSearchIds = currentSearchIds.Except(alreadyNotifiedSearchIds).ToList();
                return newSearchIds;
            } else
            {             
                List<long> newSearchIds = currentSearchIds;
                return newSearchIds;
            }
        }

        //UPDATES THE CONFIGFILE WITH THE NEWLY NOTIFIED IDS
        public void updateAlreadyNotifiedIds (List<long> newSearchIds)
        {

            string jsonstring = File.ReadAllText(this.confFile_path);
            List<long> updatedAlreadyNotifiedSearchIds = new List<long>();

            if (jsonstring != "")
            {
                List<long> alreadyNotifiedSearchIds = JsonConvert.DeserializeObject<List<long>>(jsonstring);

                
                updatedAlreadyNotifiedSearchIds.AddRange(alreadyNotifiedSearchIds);
                updatedAlreadyNotifiedSearchIds.AddRange(newSearchIds);

                
            }
            else
            {
                updatedAlreadyNotifiedSearchIds.AddRange(newSearchIds);

            }
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
