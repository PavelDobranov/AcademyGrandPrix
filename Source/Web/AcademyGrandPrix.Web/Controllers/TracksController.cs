using System.Web.Mvc;

using AcademyGrandPrix.Services.Data.Contracts;
using AcademyGrandPrix.Web.ViewModels.Tracks;
using AcademyGrandPrix.Web.Infrastructure.Mappings;

namespace AcademyGrandPrix.Web.Controllers
{
    public class TracksController : BaseController
    {
        private readonly ITracksService tracks;

        public TracksController(ITracksService tracks)
        {
            this.tracks = tracks;
        }

        [HttpGet]
        public ActionResult List()
        {
            var tracks = this.tracks.GetAll().To<TrackViewModel>();

            var viewModel = new PageableTracksListViewModel
            {
                CurrentPage = 1,
                TotalPages = 1,
                Tracks = tracks
            };

            return this.View(viewModel);
        }
    }
}