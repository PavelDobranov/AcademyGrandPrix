using System;
using AcademyGrandPrix.Data.Common;
using AcademyGrandPrix.Data.Models;
using AcademyGrandPrix.Services.Data.Contracts;

namespace AcademyGrandPrix.Services.Data
{
    public class CompetitionsService : ICompetitionsService
    {
        private readonly IDbRepository<Competition> competitions;
        private readonly IDbRepository<User> users;

        public CompetitionsService(IDbRepository<Competition> competitions, IDbRepository<User> users)
        {
            this.competitions = competitions;
            this.users = users;
        }

        public Competition GetById(int id)
        {
            return this.competitions.GetById(id);
        }

        public void Create(string CreaotrId, int TrackId, CompetitionType type, bool IsPublic, int lapsCount, DateTime startDateTime, DateTime endDateTime)
        {
            var competition = new Competition
            {
                TrackId = TrackId,
                Type = type,
                IsPublic = IsPublic,
                LapsCount = lapsCount,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime
            };

            this.competitions.Add(competition);
            this.competitions.Save();
        }

        public void AddContester(string userId, object competitionId)
        {
            var user = this.users.GetById(userId);
            var competition = this.competitions.GetById(competitionId);

            competition.Contesters.Add(user);
            this.competitions.Save();
        }
    }
}