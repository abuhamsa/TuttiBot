using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TuttiBot
{   //GENERATED FROM https://jsonutils.com/
    class Item
    {
        //GENERATED FROM https://jsonutils.com/
        public string id { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public CategoryInfo category_info { get; set; }
        public bool company_ad { get; set; }
        public int epoch_time { get; set; }
        public bool highlight { get; set; }
        public IList<string> image_names { get; set; }
        public string language { get; set; }
        public LocationInfo location_info { get; set; }
        public string phone_hash { get; set; }
        public IList<Parameter> parameters { get; set; }
        public IList<OrderedParameter> ordered_parameters { get; set; }
        public string price { get; set; }
        public string public_account_id { get; set; }
        public string thumb_name { get; set; }
        public string type { get; set; }
        public string user_alias { get; set; }

        //CREATES AN OFFER OUT OF AN ITEM
        public Offer toOffer(Item item)

        {

            Offer offer = new Offer();
            offer.offer_id = item.id;
            offer.published = item.fromUnixTime(item.epoch_time).ToString();
            offer.price = item.price;
            offer.thumb_url = "https://c.tutti.ch/gallery/"+item.thumb_name;
            offer.title = item.subject;
            offer.description = item.body;
            offer.link = "https://www.tutti.ch/de/vi/" + item.id; ;

            return offer;
        }

        //CONVERTS EPOCHTIME/UNIXTIME TO DATETIME
        private  DateTime fromUnixTime (long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
            return epoch.AddSeconds(unixTime);
        }
        

    }

    //GENERATED FROM https://jsonutils.com/
    public class CategoryInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string parent_id { get; set; }
        public string parent_name { get; set; }
    }
    //GENERATED FROM https://jsonutils.com/
    public class LocationInfo
    {
        public string plz { get; set; }
        public int region_id { get; set; }
        public string region_name { get; set; }
        public string geo_address { get; set; }
    }
    //GENERATED FROM https://jsonutils.com/
    public class Parameter
    {
        public string id { get; set; }
        public string value { get; set; }
        public string label { get; set; }
    }
    //GENERATED FROM https://jsonutils.com/
    public class OrderedParameter
    {
        public string id { get; set; }
        public string value { get; set; }
        public string label { get; set; }
    }

 
}
