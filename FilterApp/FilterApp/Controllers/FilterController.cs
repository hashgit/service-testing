using App.Services;
using FilterApp.Attributes;
using FilterApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilterApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FilterController : Controller
    {
        private readonly IFilterService _filterService;

        public FilterController(IFilterService filterService)
        {
            _filterService = filterService;
        }

        [JsonValidator]
        [HttpPost]
        public IActionResult Post([FromBody] RequestModel requestModel)
        {
            var filteredShows = _filterService.DoFilter(requestModel?.payload);
            
            if (filteredShows != null)
            {
                return Ok(new ResponseModel { response = filteredShows });
            }

            return BadRequest();
        }
    }
}