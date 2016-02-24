namespace AcademyGrandPrix.Web.Infrastructure.Populators
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AcademyGrandPrix.Services.Data.Contracts;
    using AcademyGrandPrix.Services.Web.Contracts;

    public class TracksPopulator : ITracksPopulator
    {
        private ITracksService tracks;
        private ICacheService cache;

        public TracksPopulator(ITracksService tracks, ICacheService cache)
        {
            this.tracks = tracks;
            this.cache = cache;
        }

        public IEnumerable<SelectListItem> GetData()
        {
            var tracks = this.cache.Get<IEnumerable<SelectListItem>>("tracks",
                () =>
                {
                    return this.tracks
                        .GetAll()
                        .Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name })
                        .ToList();
                }, 60 * 10);

            return tracks;
        }
    }
}
