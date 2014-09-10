using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace UTARadio
{
    class M3UHandler
    {
        string BASE_URL;
        WebClient client;

        public M3UHandler(string baseURL)
        {
            if (baseURL == null || baseURL.Length == 0)
            {
                throw new ApplicationException("Specify the URI of the resource to retrieve.");
            }
            BASE_URL = baseURL;

            //download the first list
            DownloadChunckListData();
        }


        private void DownloadChunckListData()
        {
            client = new WebClient();
            client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
            client.OpenReadAsync(new Uri(BASE_URL));
        }

        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
                byte[] buffer = new byte[1024];
                e.Result.Read(buffer, 0, buffer.Length);

                string s = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        }

    }
}
