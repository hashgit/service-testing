using App.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace App.Services
{
    public interface IFilterService
    {
        IList<FilteredShow> DoFilter(IEnumerable<Show> shows);
    }

    public class FilterService : IFilterService
    {
        public IList<FilteredShow> DoFilter(IEnumerable<Show> shows)
        {
            if (shows != null)
            {
                return shows
                    .Where(s => s.drm && s.episodeCount > 0)
                    .Select(s => new FilteredShow()
                        {
                            title = s.title,
                            slug = s.slug,
                            image = s.image?.showImage
                        }
                    )
                    .ToList();
            }

            return null;
        }
    }
}
