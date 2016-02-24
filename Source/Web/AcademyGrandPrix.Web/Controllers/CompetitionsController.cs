﻿using System;
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
    }
}