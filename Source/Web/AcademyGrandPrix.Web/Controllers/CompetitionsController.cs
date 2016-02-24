using System;
using System.Linq;

using System.Web.Mvc;

using AcademyGrandPrix.Services.Data.Contracts;
using AcademyGrandPrix.Web.ViewModels.Competitions;
using AcademyGrandPrix.Web.Infrastructure.Populators;

namespace AcademyGrandPrix.Web.Controllers
{
    public class CompetitionsController : BaseController
    {
        private readonly ICompetitionsService competitions;
        private readonly ITracksPopulator tracksPopulator;

        public CompetitionsController(ICompetitionsService competitions, ITracksPopulator tracksPopulator)
        {
            this.competitions = competitions;
            this.tracksPopulator = tracksPopulator;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            // TODO: add optional Id for specific Tack

            var tracks = this.tracksPopulator.GetData();

            var viewModel = new CreateCompetitionViewModel
            {
                Tracks = tracks
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCompetitionViewModel model)
        {
            model.Tracks = this.tracksPopulator.GetData();

            this.competitions.Create(this.UserId, model.TrackId, model.Type, model.IsPublic, model.LapsCount, model.StartDateTime, model.EndDateTime);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var competition = this.competitions.GetById(id);
            var viewModel = this.Mapper.Map<CompetitionViewModel>(competition);

            return this.View(viewModel);
        }

        public ActionResult Join(int id)
        {
            var userId = this.UserId;

            this.competitions.AddContester(userId, id);

            return this.Json(new { Success = true });
        }
    }
}