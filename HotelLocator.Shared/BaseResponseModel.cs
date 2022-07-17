using System.Net;

namespace HotelLocator.Shared
{
    public class BaseResponseModel
    {
        public bool Success { get; set; } = true;
        public HttpStatusCode ResponseCode { get; set; } = HttpStatusCode.OK;
        public string? Message { get; set; }
    }
}