using System;
using System.Linq;

using System.Web.Mvc;

using AcademyGrandPrix.Services.Data.Contracts;
using AcademyGrandPrix.Web.ViewModels.Votes;

namespace AcademyGrandPrix.Web.Controllers
{
    public class VotesController : BaseController
    {
        private readonly IVotesService votes;

        public VotesController(IVotesService votes)
        {
            this.votes = votes;
        }

        public ActionResult Create(CreateVoteInputModel model)
        {
            // TODO: Validate model and user

            this.votes.Create(model.TrackId, this.UserId, model.Value);

            return this.Json(true);
        }
    }
}