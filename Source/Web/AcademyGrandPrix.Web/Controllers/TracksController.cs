namespace AcademyGrandPrix.Web.Controllers
{
    using System;
    using System.Linq;

    using System.Web;
    using System.Web.Mvc;

    using AcademyGrandPrix.Services.Data.Contracts;
    using AcademyGrandPrix.Web.Infrastructure.ImageProcessing;
    using AcademyGrandPrix.Web.Infrastructure.Mappings;
    using AcademyGrandPrix.Web.ViewModels.Tracks;

    public class TracksController : BaseController
    {
        private const int ItemsPerPage = 3;

        private readonly ITracksService tracks;
        private readonly IImagesService images;
        private readonly IProcessImageHelper processImageHelper;

        public TracksController(ITracksService tracks, IImagesService images, IProcessImageHelper processImageHelper)
        {
            this.tracks = tracks;
            this.processImageHelper = processImageHelper;
            this.images = images;
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
            var track = this.tracks.GetById(id);
            var viewModel = this.Mapper.Map<TrackViewModel>(track);

            return this.View(viewModel);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTrackViewModel model)
        {
            var imageContent = this.processImageHelper.ProcessImage(model.UploadedImage);
            var imageFileExtension = model.UploadedImage.FileName.Split(new[] { '.' }).Last();

            this.tracks.Create(model.Name, model.Length, model.Difficulty, imageContent, imageFileExtension);

            return this.View();
        }

        public ActionResult Image(int id)
        {
            var image = this.images.GetById(id);

            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return File(image.Content, "image/" + image.FileExtension);
        }
    }
}