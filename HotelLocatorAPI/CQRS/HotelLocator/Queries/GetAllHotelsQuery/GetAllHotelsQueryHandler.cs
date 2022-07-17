using HotelLocator.Services;
using HotelLocator.Shared.ResponseModels;
using MediatR;

namespace HotelLocator.API.CQRS.HotelLocator.Queries.GetAllHotelsQuery
{
    public class GetAllHotelsQueryHandler :
        IRequestHandler<GetAllHotelsQuery, IEnumerable<GetAllHotelsQueryResponse>>
    {

        private readonly IHotelLocatorService _hotelLocatorService;

        public GetAllHotelsQueryHandler(IHotelLocatorService hotelLocatorService)
        {
            _hotelLocatorService = hotelLocatorService;
        }

        public Task<IEnumerable<GetAllHotelsQueryResponse>> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
