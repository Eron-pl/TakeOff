using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeOff.Resources;

namespace TakeOff.Services
{
    public class InstallAll
    {
        public void Install(List<Program> programs)
        {
            foreach (var item in programs)
            {
                item.Install();
            }
        }
    }
}
