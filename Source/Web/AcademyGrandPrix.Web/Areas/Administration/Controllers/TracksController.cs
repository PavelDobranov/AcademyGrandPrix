using AcademyGrandPrix.Services.Data.Contracts;
using AcademyGrandPrix.Web.Infrastructure.Mappings;
using AcademyGrandPrix.Web.ViewModels.Tracks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections;
using System.Web.Mvc;

namespace AcademyGrandPrix.Web.Areas.Administration.Controllers
{

    public class TracksController : AdminController
    {
        private readonly ITracksService tracks;

        public TracksController(ITracksService tracks)
        {
            this.tracks = tracks;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.tracks.GetAll().To<TrackViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        //public ActionResult Create([DataSourceRequest]DataSourceRequest request, TrackViewModel model)
        //{
        //    this.tracks.Create(model.Name, model.Length, model.Difficulty);

        //    var result = this.tracks.GetAll().To<TrackViewModel>().ToDataSourceResult(request);

        //    return this.Json(result);
        //}


    }
}
//public string Name { get; set; }

//public double Length { get; set; }

//public TrackDifficultyType Difficulty { get; set; }

//public string MapUrl { get; set; }

//public int VotesCount { get; set; }

//public int Rating { get; set; }