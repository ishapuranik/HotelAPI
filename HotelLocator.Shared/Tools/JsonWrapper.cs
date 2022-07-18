using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLocator.Shared.Tools
{
    public class JsonWrapper : IJsonWrapper
    {
        public string GetJsonFilePath()
        {
            string fullPath = AppDomain.CurrentDomain.BaseDirectory;

            //get the folder that's in
            return Path.Combine(fullPath + "\\JsonData\\Hotels.json");
        }
    }
}
