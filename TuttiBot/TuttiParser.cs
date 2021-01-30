using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

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
           

        }      

        //LOADING TUTTI.CH SEARCH HTML AND CREATES OFFER LIST WITH HTMLAGILITYPACK WITH HEADLESSCHROME
        //OBSOLETE DOES NOT WORK ATM
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
            chromeDriverService.HideCommandPromptWindow = true;    // This is to hide the console.
            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            driver.Navigate().GoToUrl(this.url);
            //SCROLLING 
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            for (int second = 0; ; second++)
            {
                if (second >= 12)
                {
                    break;
                }
                jse.ExecuteScript("window.scrollBy(0, 480)", ""); //480px nach unten scrollen
                Thread.Sleep(300);
            }
            //TODO: CHROMESTUFF VIELLEICHT IN EIGENE KLASSE SCHIEBEN

            //HTMLDOCUMENT FROM HTML AGILITY PACK
            var doc = new HtmlDocument();
            doc.LoadHtml(driver.PageSource);

            HtmlNodeCollection htmlNodes = doc.DocumentNode.SelectNodes("//div[@class='_228GQ _3HmX7']");

            List<Offer> offers = new List<Offer>();

            //RUNS FOR EVERY "CLASS=_228GQ _3HmX7"-DIV FOUND IN THE ROOT HTML
            foreach (HtmlNode node in htmlNodes)
            {
                Offer offer = new Offer();

                //IN "CLASS=_228GQ _3HmX7"-DIV ARE THE INFOS FOR ID, PUBLISHED, PRICE, THUMB, TITLE, DESCRIPTION, LINK
                try
                {
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
                catch (NullReferenceException e)
                {
                    //PRO ENTRIES HAVE A DIFFENT XPATH "./div[@class='_1abn1 _2KsM3 _2g4HX']" THIS LEADS TO A NULLPOINTER-EXEPTION 
                    Console.WriteLine(e.ToString());

                }



               
                
            }

           
            return offers;
        }

        //REMOVE WHITE SPACES FROM STRINGS
        public string sanitize(string tobecleaned)
        {
            string clean = Regex.Replace(tobecleaned, @"\r\n?|\n|\t|\r|^(\s*)", "");
            return clean;
        }

        //LOADING TUTTI.CH SEARCH JSON AND CREATES OFFER LIST WITH HTMLAGILITYPACK
        public List<Offer> loadNextractJson()
        {
            var url = this.url;
            var web = new HtmlWeb();
            var doc = web.Load(url);
            //XPATH TO THE JSON-STRING
            HtmlNode htmlNode = doc.DocumentNode.SelectSingleNode("/html/body/script[1]");
            string rawjson = htmlNode.InnerText;
            //SUBSTRING FOR GET ONLY JSON STUFF
            string onlyjson = rawjson.Substring(rawjson.IndexOf("{"));

            //CREATES JOBJECT OUT OF THE JSON-STRING
            JObject wholeJson = JsonConvert.DeserializeObject<JObject>(onlyjson);

            //THE LAST JTOKEN IS THE JTOKEN WITH THE OFFERS INCLUDED
            JToken itemsjt = wholeJson.Last.Last;
            
            //CREATE THE LIST WITH OFFER OBJECTS THAT WE WILL RETURN
            List<Offer> offers = new List<Offer>();

            foreach (JToken token in itemsjt)
            {
                //THE LAST TOKEN HAS THE INFORMATIONS FOR 1 ITEM/OFFER
                Item item =token.Last.ToObject<Item>();

                //THE METHOD TOOFFER CREATES A OFFER OUT OF AN ITEM
                offers.Add(item.toOffer(item));
            }
            
           
            


            return offers;
        }


    }
}
