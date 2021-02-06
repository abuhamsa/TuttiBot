using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
using Telegram.Bot;

namespace TuttiBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (ConfigurationManager.AppSettings["userkey"] != "")
            {
                txt_api.Text = txt_api.Text = ConfigurationManager.AppSettings["userkey"];
            }
            else txt_api.Text = "set your API-Key here";
        }

        private Boolean running;

        private async void button2_Click(object sender, EventArgs e)
        {
            
            running = true;

            while (running)
            {
                txt_filepath.Enabled = false;
                btn_choosefile.Enabled = false;
                btn_runsearch.Enabled = false;
                grp_provider.Enabled = false;
                txt_interval.Enabled = false;
                txt_searchterm.Enabled = false;
                txt_api.Enabled = false;
                btn_setapi = false;
                btn_stop.Enabled = true;

                List<string> searchTerms = txt_searchterm.Text.Split(';').ToList<string>();

                foreach (string searchTerm in searchTerms)
                {


                    txt_log.AppendText(DateTime.Now.ToString("HH:mm:ss") + " - START SEARCH FOR " + searchTerm + "\r\n");
                    //CREATES A TUTTIPARSER OBJECT WITH THE CURRENT SEARCHTERM
                    TuttiParser tuttiParser = new TuttiParser("https://www.tutti.ch/ganze-schweiz/angebote?q=" + searchTerm);

                    //CREATES A LIST OF OFFERS FROM THE TUTTIPARSER OBJECT


                    List<Offer> offers = tuttiParser.loadNextractJson();
                    txt_log.AppendText(DateTime.Now.ToString("HH:mm:ss") + " - OFFERS LOADED\r\n");

                    //CREATES A NEW SEARCHIDSNOTIFYHANDLERJSON OBJECT WHICH IS USED TO NOW WICHT IDS ARE NEW AND WHICH ARE ALREADY NOTIFIED
                    string configpath = "C:\\Users\\reberja\\Documents\\tuttibot\\alreadynotifiedids.json";
                    if (txt_filepath.Text != "")
                    {
                        configpath = txt_filepath.Text;

                    }
                    SearchIdsNotifyHandlerJson searchIdsNotifyHandlerJson = new SearchIdsNotifyHandlerJson(configpath);

                    List<long> unnotifiedIds = searchIdsNotifyHandlerJson.getUnnotifiedIds(offers);
                    txt_log.AppendText(DateTime.Now.ToString("HH:mm:ss") + " - GOT UNNOTIFIED IDS [" + unnotifiedIds.Count + "]\r\n");

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
                            txt_log.AppendText(DateTime.Now.ToString("HH:mm:ss") + " - OFFER (" + offer.offer_id + ") SENT [" + i + "/" + unnotifiedIds.Count + "]\r\n");
                            i++;
                        }
                    }

                    //UPDATE THE ALREADYNOTIFIED-CONFIGFILE AFTER THE DELIVERY 
                    searchIdsNotifyHandlerJson.updateAlreadyNotifiedIds(searchIdsNotifyHandlerJson.getUnnotifiedIds(offers));
                    txt_log.AppendText(DateTime.Now.ToString("HH:mm:ss") + " - NOTIFIED OFFERS UPDATED\r\n");
                    txt_log.AppendText(DateTime.Now.ToString("HH:mm:ss") + " - END\r\n");

                    
                }

                if (txt_interval.Text == "")
                {
                    await Task.Delay(10000);
                }
                else
                {
                    await Task.Delay(int.Parse(txt_interval.Text));
                }
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
            txt_log.AppendText(DateTime.Now.ToString("HH:mm:ss") + " - SEARCH STOPPED\r\n");
            txt_filepath.Enabled = true;
            btn_choosefile.Enabled = true;
            btn_runsearch.Enabled = true;
            grp_provider.Enabled = true;
            txt_interval.Enabled = true;
            txt_searchterm.Enabled = true;
            txt_api.Enabled = true;
            btn_setapi.Enabled = true;
            btn_stop.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    notifyIcon1.Visible = true;
                    this.Hide();
                    e.Cancel = true;
                }
            
        } 

        

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Show();
            txt_log.SelectionStart = txt_log.TextLength;
            txt_log.ScrollToCaret();
        }

        private void toolStripMenuItem1_Click(object sender,EventArgs e)
        {
            Environment.Exit(0);
        }

        private void rbtn_pushover_CheckedChanged(object sender, EventArgs e)
        {
            lbl_api.Text = "User-Key:";
            txt_api.Text = ConfigurationManager.AppSettings["userkey"];
        }

        private void rbtn_telegram_CheckedChanged(object sender, EventArgs e)
        {
            lbl_api.Text = "Chat-ID:";
            txt_api.Text = ConfigurationManager.AppSettings["telegramchatid"];
        }

        private void btn_setapi_Click(object sender, EventArgs e)
        {
            var checkedProviderButton = grp_provider.Controls.OfType<RadioButton>()
                                              .FirstOrDefault(r => r.Checked);
            if (checkedProviderButton.Text == "Pushover")
            {
                ConfigurationManager.AppSettings.Set("userkey", txt_api.Text);
            }
            else
            {
                ConfigurationManager.AppSettings.Set("telegramchatid", txt_api.Text);
            }
             
        }
    }
}
