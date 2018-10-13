using System.Collections.Generic;

namespace App.Services.Models
{
    public class Show
    {
        public string country { get; set; }
        public string description { get; set; }
        public bool drm { get; set; }
        public int episodeCount { get; set; }
        public string genre { get; set; }
        public Image image { get; set; }
        public string language { get; set; }
        public object nextEpisode { get; set; }
        public string primaryColour { get; set; }
        public List<Season> seasons { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public string tvChannel { get; set; }
    }

    public class Image
    {
        public string showImage { get; set; }
    }

    public class Season
    {
        public string slug { get; set; }
    }
}
