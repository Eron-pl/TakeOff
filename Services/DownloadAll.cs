using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeOff.Resources;

namespace TakeOff.Services
{
    public class DownloadAll
    {
        public void Download(List<Program> programs)
        {
            //Pattern: strategy
            foreach (var item in programs)
            {
                //Jeżeli isSelected = true, pobierz program za pomocą .Download()
                    item.Download();
            }
        }
    }
}
