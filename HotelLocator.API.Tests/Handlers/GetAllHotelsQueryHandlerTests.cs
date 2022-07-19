using FluentAssertions;
using HotelLocator.API.CQRS.HotelLocator.Queries.GetAllHotelsQuery;
using HotelLocator.Services;
using HotelLocator.Shared.ResponseModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            hotelList.Add(new HotelListModel() { id = 1, name = "Hotel 1", description = "Hotel 1 Description", location = "England", rating = 3 });
            hotelList.Add(new HotelListModel() { id = 2, name = "Hotel 2", description = "Hotel 2 Description", location = "England", rating = 4 });


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
