namespace AcademyGrandPrix.Services.Data
{
    using System;
    using System.Linq;

    using AcademyGrandPrix.Data.Common;
    using AcademyGrandPrix.Data.Models;
    using AcademyGrandPrix.Services.Data.Contracts;

    public class TracksService : ITracksService
    {
        private readonly IDbRepository<Track> tracks;

        public TracksService(IDbRepository<Track> tracks)
        {
            this.tracks = tracks;
        }

        public IQueryable<Track> GetAll()
        {
            return this.tracks.All();
        }

        public Track GetById(int id)
        {
            return this.tracks.All().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Track> GetByDifficulty(TrackDifficultyType difficulty)
        {
            return this.tracks.All().Where(x => x.Difficulty == difficulty);
        }

        public void Create(string name, double length, TrackDifficultyType difficulty, byte[] imageContent, string imageFileExtension)
        {
            var trackMap = new Image
            {
                Content = imageContent,
                FileExtension = imageFileExtension
            };

            var track = new Track
            {
                Name = name,
                Length = length,
                Difficulty = difficulty,
                Map = trackMap
            };

            this.tracks.Add(track);
            this.tracks.Save();
        }
    }
}
