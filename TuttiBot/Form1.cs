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
using System.Threading;
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

        private Boolean running;

        private async void button2_Click(object sender, EventArgs e)
        {
            running = true;
            while (running)
            {
                txt_log.AppendText(DateTime.Now.ToString("hh:mm:ss") + " - START\r\n");
                //CREATES A TUTTIPARSER OBJECT WITH THE CURRENT SEARCHTERM
                TuttiParser tuttiParser = new TuttiParser("https://www.tutti.ch/ganze-schweiz/angebote?q=" + txt_searchterm.Text);

                //CREATES A LIST OF OFFERS FROM THE TUTTIPARSER OBJECT

                
                List<Offer> offers = tuttiParser.loadNextractJson();
                txt_log.AppendText(DateTime.Now.ToString("hh:mm:ss") + " - OFFERS LOADED\r\n");

                //CREATES A NEW SEARCHIDSNOTIFYHANDLERJSON OBJECT WHICH IS USED TO NOW WICHT IDS ARE NEW AND WHICH ARE ALREADY NOTIFIED
                string configpath = "C:\\Users\\reberja\\Documents\\tuttibot\\alreadynotifiedids.json";
                if (txt_filepath.Text != "")
                {
                    configpath = txt_filepath.Text;

                }
                SearchIdsNotifyHandlerJson searchIdsNotifyHandlerJson = new SearchIdsNotifyHandlerJson(configpath);

                List<long> unnotifiedIds = searchIdsNotifyHandlerJson.getUnnotifiedIds(offers);
                txt_log.AppendText(DateTime.Now.ToString("hh:mm:ss") + " - GOT UNNOTIFIED IDS [" + unnotifiedIds.Count + "]\r\n");

                //CREATES A NEW DELIVERYHANDLER WITH THE PROVIDER "PUSHOVER"
                var checkedProviderButton = grp_provider.Controls.OfType<RadioButton>()
                                          .FirstOrDefault(r => r.Checked);
                DeliveryHandler deliveryHandler = new DeliveryHandler(checkedProviderButton.Text);


                //CHECKS IF THE OFFERIDS OF OFFERS WITH THE UNOTIFIEDIDS FROM ABOVE
                int i = 1;
                foreach (Offer offer in offers)
                {

                    if (unnotifiedIds.Contains(long.Parse(offer.offer_id)))
                    {

                        //deliveryHandler.sendTextOnly(offer);
                        await deliveryHandler.sendCompleteAsync(offer);
                        txt_log.AppendText(DateTime.Now.ToString("hh:mm:ss") + " - OFFER (" + offer.offer_id + ") SENT [" + i + "/" + unnotifiedIds.Count + "]\r\n");
                        i++;
                    }
                }

                //UPDATE THE ALREADYNOTIFIED-CONFIGFILE AFTER THE DELIVERY 
                searchIdsNotifyHandlerJson.updateAlreadyNotifiedIds(searchIdsNotifyHandlerJson.getUnnotifiedIds(offers));
                txt_log.AppendText(DateTime.Now.ToString("hh:mm:ss") + " - NOTIFIED OFFERS UPDATED\r\n");
                txt_log.AppendText(DateTime.Now.ToString("hh:mm:ss") + " - END\r\n");

                await Task.Delay(10000);

            }


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

        private void btn_stop_Click(object sender, EventArgs e)
        {
            running = false;
            txt_log.AppendText(DateTime.Now.ToString("hh:mm:ss") + " - SEARCH STOPPED\r\n");
        }
    }
}
