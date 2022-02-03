using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeOff
{
    public class Installer
    {
        public static bool Install(string url)
        {
            try
            {
                var path = @"C:\TakeOff Downloads\" + url;
                Process.Start(path);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
