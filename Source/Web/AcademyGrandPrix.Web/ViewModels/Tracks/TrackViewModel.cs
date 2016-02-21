namespace AcademyGrandPrix.Web.ViewModels.Tracks
{
    using System.Linq;

    using AutoMapper;

    using AcademyGrandPrix.Data.Models;
    using AcademyGrandPrix.Web.Infrastructure.Mappings.Contracts;

    public class TrackViewModel : IMapFrom<Track>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public double Length { get; set; }

        public TrackDifficultyType Difficulty { get; set; }

        public string MapUrl { get; set; }
        
        public int VotesCount { get; set; }

        public int Rating { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Track, TrackViewModel>()
                .ForMember(x => x.MapUrl, opt => opt.MapFrom(t => t.Map.UrlPath))
                .ForMember(x => x.VotesCount, opt => opt.MapFrom(t => t.Votes.Count()))
                .ForMember(x => x.Rating, opt => opt.MapFrom(t => t.Votes.Any() ? t.Votes.Sum(r => r.Value) : 0));
        }
    }
}