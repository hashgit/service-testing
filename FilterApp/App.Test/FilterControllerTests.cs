using App.Services;
using App.Services.Models;
using FilterApp.Controllers;
using FilterApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace App.Test
{
    public class FilterControllerTests
    {
        [Fact]
        public void ReturnsBadRequestForNull()
        {
            var filterService = new Mock<IFilterService>();
            var controller = new FilterController(filterService.Object);

            var result = controller.Post(null);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void ShouldFilterWhenRequestIsValid()
        {
            var filterService = new Mock<IFilterService>();

            var controller = new FilterController(filterService.Object);

            var data = new List<Show>()
            {
                new Show { country = "AU" }
            };

            filterService.Setup(x => x.DoFilter(data))
                .Returns(new List<FilteredShow> {
                    new FilteredShow { title = "abc" }
                });

            var result = controller.Post(new RequestModel { payload = data });

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ResponseModel>(okResult.Value);

            Assert.Single(returnValue.response);
        }
    }
}
