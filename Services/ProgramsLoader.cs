using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeOff.Resources;
using Newtonsoft.Json;
using System.IO;

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
            var jsonText = File.ReadAllText(_path);
            var programs = JsonConvert.DeserializeObject<List<Program>>(jsonText);
            return programs;
        }
    }
}
