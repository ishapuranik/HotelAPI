using System.Collections.Generic;


namespace HotelLocator.Shared.ResponseModels
{
    public class GetAllHotelsSearchQueryResponse : BaseResponseModel
    {
        public List<HotelSearchListModel> HotelSearchListDto { get; set; }
    }

    public class HotelSearchListModel 
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public int rating { get; set; }
    }
}
