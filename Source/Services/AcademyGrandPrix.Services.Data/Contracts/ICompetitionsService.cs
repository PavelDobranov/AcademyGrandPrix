using System;
using AcademyGrandPrix.Data.Models;

namespace AcademyGrandPrix.Services.Data.Contracts
{
    public interface ICompetitionsService
    {
        Competition GetById(int id);

        void Create(string CreaotrId, int TrackId, CompetitionType type, bool IsPublic, int lapsCount, DateTime startDateTime, DateTime endDateTime);

        void AddContester(string userId, object competitionId);
    }
}
