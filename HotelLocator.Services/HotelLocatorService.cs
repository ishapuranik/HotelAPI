using HotelLocator.Shared.ResponseModels;
using HotelLocator.Shared.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HotelLocator.Services
{
    public class HotelLocatorService : IHotelLocatorService
    {
        private readonly IJsonWrapper _jsonWrapper;

        public HotelLocatorService(IJsonWrapper jsonWrapper)
        {
            _jsonWrapper = jsonWrapper;
        }

        public async Task<List<HotelListModel>> GetAllHotels()
        {
            string filePath = _jsonWrapper.GetJsonFilePath();

            if (File.Exists(filePath))
                using (StreamReader r = new StreamReader(filePath))
                {
                    string json = r.ReadToEnd();
                    if (!string.IsNullOrWhiteSpace(json))
                        return JsonConvert.DeserializeObject<List<HotelListModel>>(json);
                }

            return new List<HotelListModel>();
        }
    }
}