using HotelLocator.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLocator.Shared.ResponseModels
{
        public class GetAllHotelsQueryResponse : BaseResponseModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    
}
