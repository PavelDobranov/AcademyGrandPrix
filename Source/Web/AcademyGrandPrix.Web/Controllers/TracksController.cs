namespace AcademyGrandPrix.Web.Controllers
{
    using System;
    using System.Linq;

    using System.Web.Mvc;

    using AcademyGrandPrix.Services.Data.Contracts;
    using AcademyGrandPrix.Web.ViewModels.Tracks;
    using AcademyGrandPrix.Web.Infrastructure.Mappings;

    public class TracksController : BaseController
    {
        private const int ItemsPerPage = 3;

        private readonly ITracksService tracks;

        public TracksController(ITracksService tracks)
        {
            this.tracks = tracks;
        }

        [HttpGet]
        public ActionResult List(int id = 1)
        {
            int page = id;
            int totalItemsCount = this.tracks.GetAll().Count();
            int totalPages = (int)Math.Ceiling(totalItemsCount / (decimal)ItemsPerPage);
            int skip = (page - 1) * ItemsPerPage;

            var tracks = this.tracks.GetAll()
                .OrderBy(x => x.Name)
                .Skip(skip)
                .Take(ItemsPerPage)
                .To<TrackViewModel>()
                .ToList();

            var viewModel = new PageableTracksListViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Tracks = tracks
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var track  = this.tracks.GetById(id);
            var viewModel = this.Mapper.Map<TrackViewModel>(track);

            return this.View(viewModel);
        }
    }
}