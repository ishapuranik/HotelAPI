using HotelLocator.Shared.ResponseModels;
using HotelLocator.Shared.Tools;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace HotelLocator.Services
{
    public class HotelLocatorService : IHotelLocatorService
    {
        private readonly IJsonWrapper _jsonWrapper;
        private readonly IMapper _mapper;

        public HotelLocatorService(IJsonWrapper jsonWrapper, IMapper mapper)
        {
            _jsonWrapper = jsonWrapper;
            _mapper = mapper;
        }

        /// <summary>
        /// Return all hotel list
        /// </summary>
        /// <returns>List<HotelListModel></returns>
        public async Task<List<HotelListModel>> GetAllHotels()
        {
            string jsonData = _jsonWrapper.ReadJsonData();

            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                return JsonConvert.DeserializeObject<List<HotelListModel>>(jsonData);
            }
            return new List<HotelListModel>();
        }

        /// <summary>
        /// Returns hotels list by search param
        /// </summary>
        /// <param name="hotelName">hotel Name</param>
        /// <param name="rating">Rating - 1 to 5</param>
        /// <returns>List<HotelListModel></returns>
        public async Task<List<HotelSearchListModel>> GetHotelsBySearchParam(string? hotelName, int? rating)
        {
            var list = GetAllHotels().Result;

            if (list == null || !list.Any())
                return new List<HotelSearchListModel>();

            var filteredList = list.Where(x => (!string.IsNullOrWhiteSpace(hotelName) && x.Name.Contains(hotelName)) || x.Rating == rating);

            if (filteredList.Any())
                return _mapper.Map<List<HotelSearchListModel>>(filteredList);

            return new List<HotelSearchListModel>();
        }
    }
}