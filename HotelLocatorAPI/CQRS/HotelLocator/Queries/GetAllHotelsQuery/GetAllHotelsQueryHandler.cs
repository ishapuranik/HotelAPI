using HotelLocator.Services;
using HotelLocator.Shared.ResponseModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLocator.API.CQRS.HotelLocator.Queries.GetAllHotelsQuery
{
    public class GetAllHotelsQueryHandler :
        IRequestHandler<GetAllHotelsQuery, GetAllHotelsQueryResponse>
    {

        private readonly IHotelLocatorService _hotelLocatorService;

        public GetAllHotelsQueryHandler(IHotelLocatorService hotelLocatorService)
        {
            _hotelLocatorService = hotelLocatorService;
        }

        public async Task<GetAllHotelsQueryResponse> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
        {
            List<HotelListModel> list = null;
            list = await _hotelLocatorService.GetAllHotels();

            return new GetAllHotelsQueryResponse() { HotelListModel = list };
        }
    }
}
