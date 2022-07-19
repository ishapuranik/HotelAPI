using HotelLocator.Services;
using HotelLocator.Shared.ResponseModels;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLocator.API.CQRS.HotelLocator.Queries.GetHotelListBySearchParam
{
    public class GetHotelListBySearchQueryHandler :
        IRequestHandler<GetHotelListBySearchQuery, GetAllHotelsSearchQueryResponse>
    {

        private readonly IHotelLocatorService _hotelLocatorService;

        public GetHotelListBySearchQueryHandler(IHotelLocatorService hotelLocatorService)
        {
            _hotelLocatorService = hotelLocatorService;
        }

        public async Task<GetAllHotelsSearchQueryResponse> Handle(GetHotelListBySearchQuery request, CancellationToken cancellationToken)
        {
            List<HotelSearchListModel> list = null;
            list = await _hotelLocatorService.GetHotelsBySearchParam(request.HotelName, request.Rating);

            return new GetAllHotelsSearchQueryResponse() { HotelSearchListDto = list };
        }
    }
}
