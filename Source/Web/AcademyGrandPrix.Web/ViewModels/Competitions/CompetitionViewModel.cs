using AcademyGrandPrix.Data.Models;
using AcademyGrandPrix.Web.Infrastructure.Mappings.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;

namespace AcademyGrandPrix.Web.ViewModels.Competitions
{
    public class CompetitionViewModel : IMapFrom<Competition>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Competition Track")]
        public string TrackName { get; set; }

        [Display(Name = "Competition Type")]
        public CompetitionType Type { get; set; }

        [Display(Name = "Is Public")]
        public bool IsPublic { get; set; }

        [Display(Name = "Number Of Laps")]
        public int LapsCount { get; set; }

        [Display(Name = "Start Date")]
        public string StartDateTime { get; set; }

        public IEnumerable<string> Contesters { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Competition, CompetitionViewModel>()
                .ForMember(x => x.TrackName, opt => opt.MapFrom(c => c.Track.Name))
                .ForMember(x => x.Contesters, opt => opt.MapFrom(c => c.Contesters.Select(x => x.UserName)));
        }
    }
}