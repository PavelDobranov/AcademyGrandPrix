namespace AcademyGrandPrix.Services.Data
{
    using AcademyGrandPrix.Data.Common;
    using AcademyGrandPrix.Data.Models;
    using AcademyGrandPrix.Services.Data.Contracts;

    public class VotesService : IVotesService
    {
        private readonly IDbRepository<Vote> votes;

        public VotesService(IDbRepository<Vote> votes)
        {
            this.votes = votes;
        }

        public void Create(int trackId, string authorId, int value)
        {
            var vote = new Vote
            {
                TrackId = trackId,
                AuthorId = authorId,
                Value = value
            };

            this.votes.Add(vote);
            this.votes.Save();
        }
    }
}
