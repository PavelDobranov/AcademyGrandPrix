namespace AcademyGrandPrix.Web.ViewModels.Tracks
{
    using System.Collections.Generic;

    public class PageableTracksListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<TrackViewModel> Tracks { get; set; }
    }
}