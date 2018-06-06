using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TuttiBot
{
    internal class TuttiParser
    {
        public string url;

        public TuttiParser(string url)
        {
            this.url = url;
        }

        //ONLY FOR TESTING
        public void firsttest() {

            var url = this.url;
            var web = new HtmlWeb();
            var doc = web.Load(url);
            HtmlNodeCollection htmlNodes = doc.DocumentNode.SelectNodes("//div[@class='in-click-th cf']");

            string offer_id = htmlNodes[0].SelectSingleNode("../@id").Id;
            string published = htmlNodes[0].SelectSingleNode("./em[@class='fl in-date']").InnerText;
            string price = htmlNodes[0].SelectSingleNode("./ span[@class = 'fl in-price']").InnerText;
            string thumb_url = htmlNodes[0].SelectSingleNode("./div[@class='li-thumb fl in-thumb']/a/img/@src").GetAttributeValue("src", string.Empty);







            //INFO_NODE PART
            var info_node = htmlNodes[0].SelectSingleNode("./div[@class='fl in-info']");
            string title = info_node.SelectSingleNode("./h3[@class='in-title']").InnerText;
            string description = info_node.SelectSingleNode("./p[@class='in-text']").InnerText;
            string link = info_node.SelectSingleNode("./h3[@class='in-title']/a/@href").GetAttributeValue("href", string.Empty);
            Console.WriteLine(title);
            Console.WriteLine(description);

            string blub = "blah";
            
    }

        //ONLY FOR TESTING
        public void multitest ()
        {

            var url = this.url;
            var web = new HtmlWeb();
            var doc = web.Load(url);
            HtmlNodeCollection htmlNodes = doc.DocumentNode.SelectNodes("//div[@class='in-click-th cf']");

            foreach (HtmlNode node in htmlNodes)
            {

                string offer_id = sanitize(node.SelectSingleNode("../@id").Id);
                string published = sanitize(node.SelectSingleNode("./em[@class='fl in-date']").InnerText);
                string price = sanitize(node.SelectSingleNode("./ span[@class = 'fl in-price']").InnerText);
                string thumb_url = sanitize(node.SelectSingleNode("./div[@class='li-thumb fl in-thumb']/a/img/@src").GetAttributeValue("src", string.Empty));

                //INFO_NODE PART
                var info_node = node.SelectSingleNode("./div[@class='fl in-info']");
                string title = sanitize(info_node.SelectSingleNode("./h3[@class='in-title']").InnerText);
                string description = sanitize(info_node.SelectSingleNode("./p[@class='in-text']").InnerText);
                string link = sanitize(info_node.SelectSingleNode("./h3[@class='in-title']/a/@href").GetAttributeValue("href", string.Empty));

                Console.WriteLine("ID: " + offer_id + "\n" + "Datum: " + published + "\n" + "Preis: " + price + "\n" + "Thumb: " + thumb_url + "\n" + "Titel: " + title + "\n" + "Beschreibung: " + description + "\n" + "Link: " + link+"\n\n");
                
            }

         
            
         

        }

        //REMOVE WHITE SPACES FROM STRINGS
        public string sanitize(string tobecleaned)
        {
            string clean = Regex.Replace(tobecleaned, @"\r\n?|\n|\t|\r|^(\s*)", "");
            return clean;
        }

        //LOADING TUTTI.CH SEARCH HTML AND CREATES OFFER LIST WITH HTMLAGILITYPACK
        public List<Offer> loadNextract()
        {
            var url = this.url;
            var web = new HtmlWeb();
            var doc = web.Load(url);
            HtmlNodeCollection htmlNodes = doc.DocumentNode.SelectNodes("//div[@class='in-click-th cf']");

            List<Offer> offers = new List<Offer>();

            //RUNS FOR EVERY "CLASS=IN-CLICK-TH CF"-DIV FOUND IN THE ROOT HTML
            foreach (HtmlNode node in htmlNodes)
            {
                Offer offer = new Offer();

                //IN "CLASS=IN-CLICK-TH CF"-DIV ARE THE INFOS FOR ID, PUBLISHED, PRICE, THUMB
                offer.offer_id = sanitize(node.SelectSingleNode("../@id").Id);
                offer.published = sanitize(node.SelectSingleNode("./em[@class='fl in-date']").InnerText);
                offer.price = sanitize(node.SelectSingleNode("./ span[@class = 'fl in-price']").InnerText);
                //Debugging
                //offer.thumb_url = sanitize(node.SelectSingleNode("./div[@class='li-thumb fl in-thumb']/a/img/@src").GetAttributeValue("src", string.Empty));
                offer.thumb_url = "test";

                //IN "CLASS=FL IN-INFO"-DIV ARE THE INFOS FOR TITLE,DESCRITPION AND LINK
                var info_node = node.SelectSingleNode("./div[@class='fl in-info']");
                offer.title = sanitize(info_node.SelectSingleNode("./h3[@class='in-title']").InnerText);
                offer.description = sanitize(info_node.SelectSingleNode("./p[@class='in-text']").InnerText);
                offer.link = sanitize(info_node.SelectSingleNode("./h3[@class='in-title']/a/@href").GetAttributeValue("href", string.Empty));

                offers.Add(offer);
               // Console.WriteLine(offer.ToString());
                
            }

           
            return offers;
        }

    }
}