namespace AcademyGrandPrix.Services.Data.Contracts
{
    using AcademyGrandPrix.Data.Models;

    public interface IImagesService
    {
        Image GetById(int id);
    }
}
