using AcademyGrandPrix.Services.Data.Contracts;
using AcademyGrandPrix.Data.Models;
using AcademyGrandPrix.Data.Common;

namespace AcademyGrandPrix.Services.Data
{
    public class ImagesService : IImagesService
    {
        private readonly IDbRepository<Image> images;

        public ImagesService(IDbRepository<Image> images)
        {
            this.images = images;
        }

        public Image GetById(int id)
        {
            return this.images.GetById(id);
        }
    }
}
