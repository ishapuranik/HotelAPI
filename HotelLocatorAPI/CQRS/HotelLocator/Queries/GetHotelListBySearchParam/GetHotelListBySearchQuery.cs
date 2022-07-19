using HotelLocator.Shared;
using HotelLocator.Shared.ResponseModels;
using MediatR;
using System.Collections.Generic;

namespace HotelLocator.API.CQRS.HotelLocator.Queries.GetHotelListBySearchParam
{
    public class GetHotelListBySearchQuery : IRequest<GetAllHotelsSearchQueryResponse>
    {
        public string? HotelName { get; set; }
        public int? Rating { get; set; }
    }

}
