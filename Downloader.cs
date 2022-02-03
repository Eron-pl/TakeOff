using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

namespace TakeOff
{
    public class Downloader
    {
        public static string FetchFilename(string url)
        {
            if (url.EndsWith("/"))
            {
                url = url.Remove(url.Length - 1);
            }
            return url.Substring(url.LastIndexOf("/") + 1);
        }

        public static bool Download(string url, string location = @"C:\TakeOff Downloads\")
        {
            //location = local path to where the file has to be saved
            //url = web url to direct file download
            try 
            {
                WebClient client = new WebClient();

                client.DownloadFile(url, location + FetchFilename(url));
                Debug.WriteLine($"Pobieram plik, po pobraniu będzie można go znaleźć w {location}");
            } 
            catch
            {
                return false;
            }
            return true;
        }
    }
}
