using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeOff.Resources
{
    public class UserConfig
    {
        private string _programsInstalationPath;

        public string ProgramsInstalationPath
        {
            get
            {
                return _programsInstalationPath;
            }
            set
            {
                _programsInstalationPath = value;
            }
        }
    }
}
