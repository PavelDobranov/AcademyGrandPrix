using System;
using AcademyGrandPrix.Data.Common;
using AcademyGrandPrix.Data.Models;
using AcademyGrandPrix.Services.Data.Contracts;

namespace AcademyGrandPrix.Services.Data
{
    public class CompetitionsService : ICompetitionsService
    {
        private readonly IDbRepository<Competition> competitions;

        public CompetitionsService(IDbRepository<Competition> competitions)
        {
            this.competitions = competitions;
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
    }
}