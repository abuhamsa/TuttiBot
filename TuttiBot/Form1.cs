using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuttiBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //CREATES A TUTTIPARSER OBJECT WITH THE CURRENT SEARCHTERM
            TuttiParser tuttiParser = new TuttiParser("https://www.tutti.ch/ganze-schweiz/angebote?q=" + textBox3.Text);

            //CREATES A LIST OF OFFERS FROM THE TUTTIPARSER OBJECT
            List<Offer> offers = tuttiParser.loadNextract();

            //CREATES A NEW SEARCHIDSNOTIFYHANDLERJSON OBJECT WHICH IS USED TO NOW WICHT IDS ARE NEW AND WHICH ARE ALREADY NOTIFIED
            SearchIdsNotifyHandlerJson searchIdsNotifyHandlerJson = new SearchIdsNotifyHandlerJson("C:\\Users\\reberja\\Documents\\tuttibot\\new_searches.json");

            List<int> unnotifiedIds = searchIdsNotifyHandlerJson.getUnnotifiedIds(offers);


            //CREATES A NEW DELIVERYHANDLER WITH THE PROVIDER "PUSHOVER"
            DeliveryHandler deliveryHandler = new DeliveryHandler("pushover");


            //CHECKS IF THE OFFERIDS OF OFFERS WITH THE UNOTIFIEDIDS FROM ABOVE
            foreach (Offer offer in offers)
            {
               
                        if (unnotifiedIds.Contains(Int32.Parse(offer.offer_id)))
                    {

                    //deliveryHandler.sendTextOnly(offer);
                    deliveryHandler.sendCompleteAsync(offer);
                    }
            }

            //UPDATE THE ALREADYNOTIFIED-CONFIGFILE AFTER THE DELIVERY
            searchIdsNotifyHandlerJson.updateAlreadyNotifiedIds(searchIdsNotifyHandlerJson.getUnnotifiedIds(offers));

           






            Pushover pushover = new Pushover("uoGz5xaAPxZQFGDJwPhEF3vJF6eeYG", "ae965hsnhmamdo12wcpmxw75fto72a");
            // pushover.sendText(offers[0].title, offers[0].ToString());

            // OldDeliveryHandlerJson deliveryHandler = new OldDeliveryHandlerJson();
            // deliveryHandler.sendNewOffersPushover(offers, textBox3.Text);

            // await pushover.pushImage( offers[0].ToString(),offers[0].thumb_url);
            // Console.WriteLine("blub");

            /*
            foreach (Offer offer in offers)
            {
                await pushover.pushImage(offer.ToString(), offer.thumb_url);
            }*/


        }
    }
}
