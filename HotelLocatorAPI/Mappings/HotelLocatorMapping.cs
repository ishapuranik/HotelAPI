using AutoMapper;
using HotelLocator.Shared.ResponseModels;

namespace HotelLocator.API.Mappings
{
    public class HotelLocatorMapping : Profile
    {
        public HotelLocatorMapping()
        {
            CreateMap<HotelListModel, HotelSearchListModel>();
        }
    }
}
