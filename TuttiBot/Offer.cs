namespace TuttiBot
{
    internal class Offer
    {

        public string offer_id { get; set; }
        public string published { get; set; }
        public string price { get; set; }
        public string thumb_url { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }


        public Offer()
        {
        }

        public Offer(string offer_id, string published, string price, string thumb_url, string title, string description, string link)
        {
            this.offer_id = offer_id;
            this.published = published;
            this.price = price;
            this.thumb_url = thumb_url;
            this.title = title;
            this.description = description;
            this.link = link;
        }

        //OVERWRITTEN TOSTRING
        public string ToString()
        {
            string offerString;

            offerString = "ID: " + offer_id + "\r\n";
            offerString += "Title: " + title + "\r\n";
            offerString += "Published: " + published + "\r\n";
            offerString += "Price: " + price + "\r\n";
            //offerString += "Thumb: " + thumb_url + "\r\n";
            offerString += "Description: " + description + "\r\n";
            offerString += "Link: " + link + "\r\n";
            offerString += "\r\n";
            return offerString;
        }
    }
}