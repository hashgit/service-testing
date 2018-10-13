using App.Services.Models;
using System.Collections.Generic;

namespace FilterApp.Models
{
    public class ResponseModel
    {
        public IEnumerable<FilteredShow> response { get; set; }
    }
}
