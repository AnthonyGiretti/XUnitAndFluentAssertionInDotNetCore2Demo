using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnitTests
{
    public static class EmbeddedJsonFileHelper
    {
        public static T GetContent<T>(string filename)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText($"{filename}.json"));
        }
    }
}
