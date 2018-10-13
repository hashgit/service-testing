using App.Services;
using App.Services.Models;
using System.Collections.Generic;
using Xunit;

namespace App.Test
{
    public class FilterServiceTests
    {
        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] {
                    new List<Show> {
                        new Show { drm = false }
                    }, 0
                },
                new object[] {
                    new List<Show> {
                        new Show { drm = false },
                        new Show { drm = true },
                        new Show { episodeCount = 1 },
                        new Show { episodeCount = 2 },
                        new Show { episodeCount = 0 },
                        new Show { episodeCount = -1 },
                    }, 0
                },
                new object[] {
                    new List<Show> {
                        new Show { drm = false, episodeCount = 1 },
                        new Show { drm = true, episodeCount = 10 },
                        new Show { episodeCount = 0, drm = true },
                    }, 1
                },
            };


        [Fact]
        public void ReturnsNullWhenGivenNull()
        {
            var filterService = new FilterService();
            var result = filterService.DoFilter(null);

            Assert.Null(result);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ShouldFilterCorrectly(IEnumerable<Show> data, int expectedCount)
        {
            var filterService = new FilterService();

            var result = filterService.DoFilter(data);
            Assert.Equal(expectedCount, result.Count);
        }
    }
}
