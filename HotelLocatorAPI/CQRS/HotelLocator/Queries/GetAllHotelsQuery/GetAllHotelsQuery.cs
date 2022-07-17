using HotelLocator.Shared;
using HotelLocator.Shared.ResponseModels;
using MediatR;

namespace HotelLocator.API.CQRS.HotelLocator.Queries.GetAllHotelsQuery
{
    public class GetAllHotelsQuery : IRequest<IEnumerable<GetAllHotelsQueryResponse>>
    {
    }

}
