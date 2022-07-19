using FluentAssertions;
using HotelLocator.Services;
using HotelLocator.Shared.ResponseModels;
using HotelLocator.Shared.Tools;
using Moq;
using Xunit;

namespace HotelLocator.API.Tests
{
    public class HotelLocatorServiceTests
    {
        [Fact]
        public void HotelLocatorService_GetAllHotels_Returns_valid_list_if_json_file_found()
        {
            //Given
            Mock<IJsonWrapper> mockJsonWrapper = new Mock<IJsonWrapper>();
            mockJsonWrapper.Setup(x => x.ReadJsonData()).Returns("[{\"id\": 1, \"name\": \"Hotel 1\", \"description\": \"Hotel 1 Description\",  \"location\" : \"England\", \"rating\": 3} , {\"id\": 2, \"name\": \"Hotel 2\", \"description\": \"Hotel 2 Description\",  \"location\" : \"England\", \"rating\": 4 } ]");

            var expectedList = new List<HotelListModel>();
            expectedList.Add(new HotelListModel() { Id = 1, Name = "Hotel 1", Description = "Hotel 1 Description", Location = "England", Rating = 3 });
            expectedList.Add(new HotelListModel() { Id = 2, Name = "Hotel 2", Description = "Hotel 2 Description", Location = "England", Rating = 4 });

            var hotelLocatorService = new HotelLocatorService(mockJsonWrapper.Object, null);

            //Act
            var result = hotelLocatorService.GetAllHotels().Result;

            //Assert
            result.Should().BeOfType<List<HotelListModel>>();
            result.Should().BeEquivalentTo(expectedList);
        }

        [Fact]
        public void HotelLocatorService_GetAllHotels_Returns__empty_list_if_file_is_empty_or_not_found()
        {
            //Given
            Mock<IJsonWrapper> mockJsonWrapper = new Mock<IJsonWrapper>();
            mockJsonWrapper.Setup(x => x.ReadJsonData()).Returns(string.Empty);

            var expectedList = new List<HotelListModel>();

            var hotelLocatorService = new HotelLocatorService(mockJsonWrapper.Object, null);

            //Act
            var result = hotelLocatorService.GetAllHotels().Result;

            //Assert
            result.Should().BeOfType<List<HotelListModel>>();
            result.Should().BeEquivalentTo(expectedList);
        }
    }
}