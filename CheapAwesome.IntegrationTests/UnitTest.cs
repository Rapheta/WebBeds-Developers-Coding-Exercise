using AutoMapper;
using CheapAwesome.Api.Controllers;
using CheapAwesome.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CheapAwesome.IntegrationTests
{
    public class UnitTest
    {
        [Theory]
        [InlineData(1419, 2)]
        public async Task Availability_GetAvailabilitySuccess_WhenDestinationIdIs1419AndNightsAre2(int destinationId, int nights)
        {
            // Arrange
            Mock<IAvailabilityService> availabilityMock = new Mock<IAvailabilityService>();
            Mock<IMapper> mapperMock = new Mock<IMapper>();
            Mock<IConfiguration> configurationMock = new Mock<IConfiguration>();
            Mock<ILogger<AvailabilityController>> loggerMock = new Mock<ILogger<AvailabilityController>>();

            var host = new Mock<IConfigurationSection>();
            host.Setup(x => x.Value).Returns("https://webbedsdevtest.azurewebsites.net/api/findBargain");

            var code = new Mock<IConfigurationSection>();
            code.Setup(x => x.Value).Returns("aWH1EX7ladA8C/oWJX5nVLoEa4XKz2a64yaWVvzioNYcEo8Le8caJw==");

            var timeout = new Mock<IConfigurationSection>();
            timeout.Setup(x => x.Value).Returns("1000");

            configurationMock.Setup(x => x.GetSection("Url:Host")).Returns(host.Object);
            configurationMock.Setup(x => x.GetSection("Url:Parameters:code")).Returns(code.Object);
            configurationMock.Setup(x => x.GetSection("Url:Timeout")).Returns(timeout.Object);

            var controller = new AvailabilityController(availabilityMock.Object, mapperMock.Object, configurationMock.Object, loggerMock.Object);

            // Act
            var result = await controller.GetAvailability(destinationId, nights);

            var okResult = result as ObjectResult;

            // Asserts
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Theory]
        [InlineData(279, 5)]
        public async Task Availability_GetAvailabilitySuccess_WhenDestinationIdIs279AndNightsAre5(int destinationId, int nights)
        {
            // Arrange
            Mock<IAvailabilityService> availabilityMock = new Mock<IAvailabilityService>();
            Mock<IMapper> mapperMock = new Mock<IMapper>();
            Mock<IConfiguration> configurationMock = new Mock<IConfiguration>();
            Mock<ILogger<AvailabilityController>> loggerMock = new Mock<ILogger<AvailabilityController>>();

            var host = new Mock<IConfigurationSection>();
            host.Setup(x => x.Value).Returns("https://webbedsdevtest.azurewebsites.net/api/findBargain");

            var code = new Mock<IConfigurationSection>();
            code.Setup(x => x.Value).Returns("aWH1EX7ladA8C/oWJX5nVLoEa4XKz2a64yaWVvzioNYcEo8Le8caJw==");

            var timeout = new Mock<IConfigurationSection>();
            timeout.Setup(x => x.Value).Returns("1000");

            configurationMock.Setup(x => x.GetSection("Url:Host")).Returns(host.Object);
            configurationMock.Setup(x => x.GetSection("Url:Parameters:code")).Returns(code.Object);
            configurationMock.Setup(x => x.GetSection("Url:Timeout")).Returns(timeout.Object);

            var controller = new AvailabilityController(availabilityMock.Object, mapperMock.Object, configurationMock.Object, loggerMock.Object);

            // Act
            var result = await controller.GetAvailability(destinationId, nights);

            var okResult = result as ObjectResult;

            // Asserts
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }
    }
}
