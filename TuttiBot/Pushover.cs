

using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TuttiBot
{
    internal class Pushover
    {
        private string appkey;
        private string userkey;

        public Pushover(string userkey, string appkey)
        {
            this.userkey = userkey;
            this.appkey = appkey;
        }

        public void pushText(string title, string text)
        {

            var parameters = new NameValueCollection {
            { "token", appkey },
            { "user", userkey },
            { "title", title },
            { "message", text }
            };

            using (var client = new WebClient())
            {
                client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
            }
        }


        public async Task pushImage( string message, string urlImage)
        {
            // This does not work - error "message cannot be blank"
            using (HttpClient httpClient = new HttpClient())
            {

                //specify to use TLS 1.2 as default connection
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                Stream streamImage = this.getImageFromURL(urlImage);

                MultipartFormDataContent form = new MultipartFormDataContent();
                form.Add(new StringContent(appkey), "\"token\"");
                form.Add(new StringContent(userkey), "\"user\"");
                form.Add(new StringContent(message), "\"message\"");
                var imageParameter = new StreamContent(streamImage);
                imageParameter.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");
                form.Add(imageParameter, "\"attachment\"", "image.png");
                // Remove content type that is not in the docs
                foreach (var param in form)
                    param.Headers.ContentType = null;

                HttpResponseMessage responseMessage = await httpClient.PostAsync("https://api.pushover.net/1/messages.json", form);
                if (responseMessage.IsSuccessStatusCode)
                    return;

                string contentText = responseMessage.Content.ReadAsStringAsync().Result;
                //var response = JsonConvert.DeserializeObject<PushResponse>(contentText);
                throw new ApplicationException(
                    $"Push image request failed with status");
            }


        }

        private Stream getImageFromURL(string urlImage)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(urlImage);
            HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return httpWebReponse.GetResponseStream(); ;
        }


    }
}