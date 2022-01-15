using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeOff.Resources
{
    class Program
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string DownloadLink { get; set; }
        public string ImagePath { get; set; }
        public bool isSelected { get; set; }


        // DO ZROBIENIA
        //
        //public bool IsInstalled(string Name)
        //{
        //    return;
        //}

        public void Download ()
        {
            Downloader.Download(DownloadLink);
        }

        public void DownloadTo(string path)
        {
            Downloader.Download(DownloadLink, path);
        }

        //public void Install (string PathToFile)
        //{

        //}

    }
}
