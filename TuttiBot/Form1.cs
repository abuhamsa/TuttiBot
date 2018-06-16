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

       

        private async void button2_Click(object sender, EventArgs e)
        {
            txt_log.Text = DateTime.Now.ToString("hh:mm:ss") + " - START";
            //CREATES A TUTTIPARSER OBJECT WITH THE CURRENT SEARCHTERM
            TuttiParser tuttiParser = new TuttiParser("https://www.tutti.ch/ganze-schweiz/angebote?q=" + txt_searchterm.Text);

            //CREATES A LIST OF OFFERS FROM THE TUTTIPARSER OBJECT
            
            List<Offer> offers = tuttiParser.loadNextract();
            txt_log.Text = txt_log.Text+"\r\n "+DateTime.Now.ToString("hh:mm:ss") + " - OFFERS LOADED";

            //CREATES A NEW SEARCHIDSNOTIFYHANDLERJSON OBJECT WHICH IS USED TO NOW WICHT IDS ARE NEW AND WHICH ARE ALREADY NOTIFIED
            string configpath = "C:\\Users\\reberja\\Documents\\tuttibot\\alreadynotifiedids.json";
            if (txt_filepath.Text != "")
            {
                configpath = txt_filepath.Text;
            }
            SearchIdsNotifyHandlerJson searchIdsNotifyHandlerJson = new SearchIdsNotifyHandlerJson(configpath);

            List<int> unnotifiedIds = searchIdsNotifyHandlerJson.getUnnotifiedIds(offers);
            txt_log.Text = txt_log.Text + "\r\n " + DateTime.Now.ToString("hh:mm:ss") + " - GOT UNNOTIFIED IDS";

            //CREATES A NEW DELIVERYHANDLER WITH THE PROVIDER "PUSHOVER"
            var checkedProviderButton = grp_provider.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            DeliveryHandler deliveryHandler = new DeliveryHandler(checkedProviderButton.Text);


            //CHECKS IF THE OFFERIDS OF OFFERS WITH THE UNOTIFIEDIDS FROM ABOVE
            foreach (Offer offer in offers)
            {
               
                        if (unnotifiedIds.Contains(Int32.Parse(offer.offer_id)))
                    {

                    //deliveryHandler.sendTextOnly(offer);
                    deliveryHandler.sendCompleteAsync(offer);
                    txt_log.Text = txt_log.Text + "\r\n " + DateTime.Now.ToString("hh:mm:ss") + " - OFFER ("+offer.offer_id+") SENT";
                }
            }

            //UPDATE THE ALREADYNOTIFIED-CONFIGFILE AFTER THE DELIVERY 
            searchIdsNotifyHandlerJson.updateAlreadyNotifiedIds(searchIdsNotifyHandlerJson.getUnnotifiedIds(offers));
            txt_log.Text = txt_log.Text + "\r\n " + DateTime.Now.ToString("hh:mm:ss") + " - NOTIFIED OFFERS UPDATED";








            //Pushover pushover = new Pushover("uoGz5xaAPxZQFGDJwPhEF3vJF6eeYG", "ae965hsnhmamdo12wcpmxw75fto72a");
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btn_choosefile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_filepath.Text = openFileDialog1.FileName;

            }
        }
    }
}
