using HotelLocator.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLocator.Services
{
    public interface IHotelLocatorService
    {
        IEnumerable<GetAllHotelsQueryResponse> GetAllHotels();
    }
}
