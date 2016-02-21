namespace AcademyGrandPrix.Web.ViewModels.Tracks
{
    using System.Linq;

    using AutoMapper;

    using AcademyGrandPrix.Data.Models;
    using AcademyGrandPrix.Web.Infrastructure.Mappings.Contracts;

    public class TrackViewModel : IMapFrom<Track>
    {
        public string Name { get; set; }

        public double Length { get; set; }

        public TrackDifficultyType Difficulty { get; set; }

        public string MapUrl { get; set; }
        
        public int Rating { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Track, TrackViewModel>()
                .ForMember(x => x.MapUrl, opt => opt.MapFrom(x => x.Map.UrlPath))
                .ForMember(x => x.Rating, opt => opt.MapFrom(x => x.Votes.Any() ? x.Votes.Sum(r => r.Value) : 0));
        }
    }
}