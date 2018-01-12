

using System.Collections.Specialized;
using System.Net;

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

        public void sendText(string title, string text)
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
    
    }
}