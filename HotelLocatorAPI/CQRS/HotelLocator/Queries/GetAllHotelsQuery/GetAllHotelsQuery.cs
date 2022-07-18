using HotelLocator.Shared;
using HotelLocator.Shared.ResponseModels;
using MediatR;
using System.Collections.Generic;

namespace HotelLocator.API.CQRS.HotelLocator.Queries.GetAllHotelsQuery
{
    public class GetAllHotelsQuery : IRequest<GetAllHotelsQueryResponse>
    {
    }

}
