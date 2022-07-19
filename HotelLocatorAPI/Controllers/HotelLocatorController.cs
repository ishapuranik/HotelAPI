using HotelLocator.API.CQRS.HotelLocator.Queries.GetAllHotelsQuery;
using HotelLocator.API.CQRS.HotelLocator.Queries.GetHotelListBySearchParam;
using HotelLocatorAPI.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLocatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelLocatorController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Get the all hotel list 
        /// </summary>
        /// <param name="logger"></param>
        public HotelLocatorController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all hotel list
        /// </summary>
        /// <param name="query">Empty model</param>
        /// <returns>IActionResult - GetAllHotelsQueryResponse</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllHotelsQuery query)
        {
            return await HandleRequest(query);
        }

        /// <summary>
        /// Get filtered list of hotels by hotel name or rating
        /// </summary>
        /// <param name="query">GetHotelListBySearchQuery</param>
        /// <returns>GetAllHotelsSearchQueryResponse</returns>
        [HttpGet("get-hotel-list-by-search-param")]
        public async Task<IActionResult> GetHotelListBySearchParam([FromQuery] GetHotelListBySearchQuery query)
        {
            return await HandleRequest(query);
        }

    }
}