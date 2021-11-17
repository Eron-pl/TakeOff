using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

namespace TakeOff
{
    class Downloader
    {
        void Download(string location, string url)
        {
            //location = local path to where the file has to be saved (including name and extension)
            //url = web url to direct file download
            WebClient client = new WebClient();

            client.DownloadFile(url, location);
            Debug.WriteLine($"Pobieram plik, po pobraniu będzie można go znaleźć w {location}");
        }
    }
}
