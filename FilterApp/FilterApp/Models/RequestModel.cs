using App.Services.Models;
using System.Collections.Generic;

namespace FilterApp.Models
{
    public class RequestModel
    {
        public IList<Show> payload { get; set; }
    }
}
