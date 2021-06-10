using CheapAwesome.Infrastructure.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace CheapAwesome.UnitTest
{
    public class UnitTests
    {
        [Fact]
        public async Task Test1()
        {
            // Arrange
            var url = "https://webbedsdevtest.azurewebsites.net/api/findBargain?destinationId=1419&nights=2&code=aWH1EX7ladA8C/oWJX5nVLoEa4XKz2a64yaWVvzioNYcEo8Le8caJw==";
            var timeout = 1000;

            //Act
            var result = await new AvailabilityRepository().GetAvailability(url, timeout);

            // Asserts
            Assert.NotNull(result);
        }
    }
}
