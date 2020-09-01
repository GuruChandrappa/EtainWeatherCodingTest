using Xunit;
using Etain.Weather.Services;
using System.Linq;

namespace Etain.Weather.Tests
{
    public class WeatherForecastDataProviderTests
    {

        [Fact]
        public void TestGetWoeIdByLocationName()
        {
            var url = "https://www.metaweather.com/api";
            var svc = new WeatherForecastDataProvider(new RestApiService(), url);
            var result = svc.GetWoeIdByLocationName("Belfast").GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.Equal(result, 44544);
        }

        [Fact]
        public void TestGetForecastByWoeId()
        {
            //Arrange
            var testWoeId = 44544;
            var nDays = 3;

            //Act
            var url = "https://www.metaweather.com/api";
            var svc = new WeatherForecastDataProvider(new RestApiService(), url);
            var result = svc.GetForecastByWoeId(testWoeId,nDays).GetAwaiter().GetResult().ToList().Take(nDays).ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(nDays, result.Count);
        }

    }
}
