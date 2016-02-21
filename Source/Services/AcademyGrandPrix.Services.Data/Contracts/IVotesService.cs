namespace AcademyGrandPrix.Services.Data.Contracts
{
    using AcademyGrandPrix.Data.Models;

    public interface IVotesService
    {
        void Create(int trackId, string authorId, int value);
    }
}
