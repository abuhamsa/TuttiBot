using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>() {
            "--silent-launch",
            "--no-startup-window",
            "no-sandbox",
            "headless",});

            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;    // This is to hidden the console.
            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            driver.Navigate().GoToUrl(this.url);
            String sourcetxt = driver.PageSource;
            
            var doc = new HtmlDocument();
            doc.LoadHtml(driver.PageSource);


            HtmlNodeCollection htmlNodes = doc.DocumentNode.SelectNodes("//div[@class='_228GQ _3HmX7']");

            List<Offer> offers = new List<Offer>();

            //RUNS FOR EVERY "CLASS=_228GQ _3HmX7"-DIV FOUND IN THE ROOT HTML
            foreach (HtmlNode node in htmlNodes)
            {
                Offer offer = new Offer();

                //IN "CLASS=_228GQ _3HmX7"-DIV ARE THE INFOS FOR ID, PUBLISHED, PRICE, THUMB, TITLE, DESCRIPTION, LINK
                offer.offer_id = sanitize(node.SelectSingleNode("./div[@class='_1abn1 _2KsM3']").Id);
                offer.published = sanitize(node.SelectSingleNode("//*[@id='" + offer.offer_id + "']/div/div[1]/div[2]/span").InnerText);
                offer.price = sanitize(node.SelectSingleNode("//*[@id=" + offer.offer_id + "]/div/div[3]/strong").InnerText);
                offer.thumb_url = sanitize(node.SelectSingleNode("//*[@id=" + offer.offer_id + "]/a/div/img/@src").GetAttributeValue("src", string.Empty));           
                offer.title = sanitize(node.SelectSingleNode("//*[@id=" + offer.offer_id + "]/div/div[2]/div/a/h4").InnerText);
                offer.description = sanitize(node.SelectSingleNode("//*[@id=" + offer.offer_id + "]/div/div[2]/div/p").InnerText);
                offer.link = sanitize("https://tutti.ch" + node.SelectSingleNode("//*[@id=" + offer.offer_id + "]/div/div[2]/div/a/@href").GetAttributeValue("href", string.Empty));



                offers.Add(offer);
                Console.WriteLine(offer.ToString());

            }

            Console.WriteLine("blahblubb");

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
            //TODO: CHROMESTUFF VIELLEICHT IN EIGENE KLASSE SCHIEBEN
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>() {
            "--silent-launch",
            "--no-startup-window",
            "no-sandbox",
            "headless",});

            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;    // This is to hidden the console.
            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            driver.Navigate().GoToUrl(this.url);
            //TODO: SCROLLING MACHEN
            var element = driver.FindElement(By.TagName("footer"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            //TODO: CHROMESTUFF VIELLEICHT IN EIGENE KLASSE SCHIEBEN

            //HTMLDOCUMENT VON HAP
            var doc = new HtmlDocument();
            doc.LoadHtml(driver.PageSource);

            HtmlNodeCollection htmlNodes = doc.DocumentNode.SelectNodes("//div[@class='_228GQ _3HmX7']");

            List<Offer> offers = new List<Offer>();

            //RUNS FOR EVERY "CLASS=_228GQ _3HmX7"-DIV FOUND IN THE ROOT HTML
            foreach (HtmlNode node in htmlNodes)
            {
                Offer offer = new Offer();

                //IN "CLASS=_228GQ _3HmX7"-DIV ARE THE INFOS FOR ID, PUBLISHED, PRICE, THUMB, TITLE, DESCRIPTION, LINK
                offer.offer_id = sanitize(node.SelectSingleNode("./div[@class='_1abn1 _2KsM3']").Id);
                offer.published = sanitize(node.SelectSingleNode("//*[@id='" + offer.offer_id + "']/div/div[1]/div[2]/span").InnerText);
                offer.price = sanitize(node.SelectSingleNode("//*[@id=" + offer.offer_id + "]/div/div[3]/strong").InnerText);
                offer.thumb_url = sanitize(node.SelectSingleNode("//*[@id=" + offer.offer_id + "]/a/div/img/@src").GetAttributeValue("src", string.Empty));
                offer.title = sanitize(node.SelectSingleNode("//*[@id=" + offer.offer_id + "]/div/div[2]/div/a/h4").InnerText);
                offer.description = sanitize(node.SelectSingleNode("//*[@id=" + offer.offer_id + "]/div/div[2]/div/p").InnerText);
                offer.link = sanitize("https://tutti.ch" + node.SelectSingleNode("//*[@id=" + offer.offer_id + "]/div/div[2]/div/a/@href").GetAttributeValue("href", string.Empty));




                offers.Add(offer);
               Console.WriteLine(offer.ToString());
                
            }

           
            return offers;
        }

    }
}
