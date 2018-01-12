using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            TuttiParser tuttiParser = new TuttiParser("https://www.tutti.ch/ganze-schweiz/angebote?q=" + textBox3.Text);
            List<Offer> offers = tuttiParser.loadNextract();
            Pushover pushover = new Pushover("uoGz5xaAPxZQFGDJwPhEF3vJF6eeYG", "ae965hsnhmamdo12wcpmxw75fto72a");
            pushover.sendText(offers[0].title, offers[0].ToString());

            DeliveryHandler deliveryHandler = new DeliveryHandler();

           
           /* foreach (Offer offer in offers)
            {
                pushover.sendText(offer.title, offer.ToString());               
            }*/
            

        }
    }
}
