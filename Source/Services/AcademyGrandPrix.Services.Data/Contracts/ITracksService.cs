namespace AcademyGrandPrix.Services.Data.Contracts
{
    using System.Linq;

    using AcademyGrandPrix.Data.Models;

    public interface ITracksService
    {
        IQueryable<Track> GetAll();

        Track GetById(int id);

        IQueryable<Track> GetByDifficulty(TrackDifficultyType difficulty);
    }
}
