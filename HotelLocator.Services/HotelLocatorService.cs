using HotelLocator.Shared.ResponseModels;
using Newtonsoft.Json;
using System.Reflection;

namespace HotelLocator.Services
{
    public class HotelLocatorService : IHotelLocatorService
    {
        public IEnumerable<GetAllHotelsQueryResponse> GetAllHotels()
        {
            //get the full location of the assembly with DaoTests in it
            string fullPath = AppDomain.CurrentDomain.BaseDirectory;

            //get the folder that's in
            string jsonFilePath = Path.Combine(fullPath + "\\HotelLocator.Data\\JsonData\\Hotels.json");

            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(json))
                   return JsonConvert.DeserializeObject<List<GetAllHotelsQueryResponse>>(json).AsEnumerable();

                return null;
            }
        }
    }
}