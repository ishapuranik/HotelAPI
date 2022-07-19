using FluentAssertions;
using HotelLocator.API.CQRS.HotelLocator.Queries.GetHotelListBySearchParam;
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
    public class GetHotelListBySearchQueryHandlerTests
    {
        [Fact]
        public void GetHotelListBySearchQueryHandler_Handle_returns_valid_model()
        {
            // Arrange
            var hotelList = new List<HotelListModel>();
            hotelList.Add(new HotelListModel() { id = 1, name = "Hotel 1", description = "Hotel 1 Description", location = "England", rating = 3 });
            hotelList.Add(new HotelListModel() { id = 2, name = "Hotel 2", description = "Hotel 2 Description", location = "England", rating = 4 });

            var hotelSearchList = new List<HotelSearchListModel>();
            hotelSearchList.Add(new HotelSearchListModel() { id = 1, name = "Hotel 1", description = "Hotel 1 Description", location = "England", rating = 3 });
            
            Mock<IHotelLocatorService> mockHotelLocatorService = new Mock<IHotelLocatorService>();
            mockHotelLocatorService.Setup(x => x.GetAllHotels()).ReturnsAsync(hotelList);

            mockHotelLocatorService.Setup(x => x.GetHotelsBySearchParam(It.IsAny<string?>(), It.IsAny<int?>())).ReturnsAsync(hotelSearchList);

            var sut = new GetHotelListBySearchQueryHandler(mockHotelLocatorService.Object);

            // Act
            var result = sut.Handle(new GetHotelListBySearchQuery() { Rating = 3 }, new CancellationToken()).Result;

            // Assert
            mockHotelLocatorService.Verify(r => r.GetHotelsBySearchParam(It.IsAny<string?>(), It.IsAny<int?>()), Times.Once);
            result.Should().BeOfType(typeof(GetAllHotelsSearchQueryResponse));
            result.HotelSearchListDto.Should().NotBeEmpty();
        }

        [Fact]
        public void GetAllHotelsQueryHandler_Handle_returns_empty_model()
        {
            // Arrange
            var hotelList = new List<HotelSearchListModel>();

            Mock<IHotelLocatorService> mockHotelLocatorService = new Mock<IHotelLocatorService>();
            mockHotelLocatorService.Setup(x => x.GetHotelsBySearchParam(It.IsAny<string?>(), It.IsAny<int?>())).ReturnsAsync(hotelList);

            var sut = new GetHotelListBySearchQueryHandler(mockHotelLocatorService.Object);

            // Act
            var result = sut.Handle(new GetHotelListBySearchQuery() { Rating = 1 }, new CancellationToken()).Result;

            // Assert
            mockHotelLocatorService.Verify(r => r.GetHotelsBySearchParam(It.IsAny<string?>(), It.IsAny<int?>()), Times.Once);
            result.Should().BeOfType(typeof(GetAllHotelsSearchQueryResponse));
            result.HotelSearchListDto.Should().BeEmpty();
        }
    }
}
