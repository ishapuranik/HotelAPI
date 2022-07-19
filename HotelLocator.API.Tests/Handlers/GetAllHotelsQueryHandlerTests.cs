using FluentAssertions;
using HotelLocator.API.CQRS.HotelLocator.Queries.GetAllHotelsQuery;
using HotelLocator.Services;
using HotelLocator.Shared.ResponseModels;
using Moq;
using Xunit;

namespace HotelLocator.API.Tests.Handlers
{
    public class GetAllHotelsQueryHandlerTests
    {
        [Fact]
        public void GetAllHotelsQueryHandler_Handle_returns_valid_model()
        {
            // Arrange
            var hotelList = new List<HotelListModel>();
            hotelList.Add(new HotelListModel() { Id = 1, Name = "Hotel 1", Description = "Hotel 1 Description", Location = "England", Rating = 3 });
            hotelList.Add(new HotelListModel() { Id = 2, Name = "Hotel 2", Description = "Hotel 2 Description", Location = "England", Rating = 4 });


            Mock<IHotelLocatorService> mockHotelLocatorService = new Mock<IHotelLocatorService>();
            mockHotelLocatorService.Setup(x => x.GetAllHotels()).ReturnsAsync(hotelList);

            var sut = new GetAllHotelsQueryHandler(
                mockHotelLocatorService.Object);

            // Act
            var result = sut.Handle(new GetAllHotelsQuery(), new CancellationToken()).Result;

            // Assert
            mockHotelLocatorService.Verify(r => r.GetAllHotels(), Times.Once);
            result.Should().BeOfType(typeof(GetAllHotelsQueryResponse));
        }

        [Fact]
        public void GetAllHotelsQueryHandler_Handle_returns_empty_model()
        {
            // Arrange
            var hotelList = new List<HotelListModel>();

            Mock<IHotelLocatorService> mockHotelLocatorService = new Mock<IHotelLocatorService>();
            mockHotelLocatorService.Setup(x => x.GetAllHotels()).ReturnsAsync(hotelList);

            var sut = new GetAllHotelsQueryHandler(
                mockHotelLocatorService.Object);

            // Act
            var result = sut.Handle(new GetAllHotelsQuery(), new CancellationToken()).Result;

            // Assert
            mockHotelLocatorService.Verify(r => r.GetAllHotels(), Times.Once);
            result.Should().BeOfType(typeof(GetAllHotelsQueryResponse));
            result.HotelListModel.Should().BeEmpty();
        }
    }
}
