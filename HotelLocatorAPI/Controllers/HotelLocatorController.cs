using HotelLocator.API.CQRS.HotelLocator.Queries.GetAllHotelsQuery;
using HotelLocatorAPI.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllHotelsQuery query)
        {
            return await HandleRequest(query);
        }

    }
}