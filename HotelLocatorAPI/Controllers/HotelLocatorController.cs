using Microsoft.AspNetCore.Mvc;

namespace HotelLocatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelLocatorController : ControllerBase
    {
       
        private readonly ILogger<HotelLocatorController> _logger;

        public HotelLocatorController(ILogger<HotelLocatorController> logger)
        {
            _logger = logger;
        }

    }
}