using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeOff.Resources;

namespace TakeOff.Services
{
    internal class ProgramsLoader
    {
        private readonly string _path;

        public ProgramsLoader(string path)
        {
            _path = path;
        }

        public List<Program> Load()
        {
            throw new NotImplementedException();
        }
    }
}
