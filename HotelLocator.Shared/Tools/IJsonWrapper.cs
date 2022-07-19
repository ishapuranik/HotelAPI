using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLocator.Shared.Tools
{
    public interface IJsonWrapper
    {
        public string GetJsonFilePath();
        public string ReadJsonData();
    }
}
