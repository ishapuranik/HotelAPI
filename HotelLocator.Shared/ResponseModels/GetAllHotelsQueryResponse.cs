using System.Collections.Generic;


namespace HotelLocator.Shared.ResponseModels
{
    public class GetAllHotelsQueryResponse : BaseResponseModel
    {
        public List<HotelListModel> HotelListModel { get; set; }
    }

    public class HotelListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Rating { get; set; }
    }
}
