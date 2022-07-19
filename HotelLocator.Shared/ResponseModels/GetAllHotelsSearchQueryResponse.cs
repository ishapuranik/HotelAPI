using System.Collections.Generic;


namespace HotelLocator.Shared.ResponseModels
{
    public class GetAllHotelsSearchQueryResponse : BaseResponseModel
    {
        public List<HotelSearchListModel> HotelSearchListDto { get; set; }
    }

    public class HotelSearchListModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Rating { get; set; }
    }
}
