namespace AcademyGrandPrix.Web.ViewModels.Tracks
{
    using AutoMapper;

    using AcademyGrandPrix.Data.Models;
    using AcademyGrandPrix.Web.Infrastructure.Mappings.Contracts;

    public class TrackViewModel : IMapFrom<Track>
    {
        public string Name { get; set; }

        public double Length { get; set; }

        public TrackDifficultyType Difficulty { get; set; }

        public string MapUrl { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Track, TrackViewModel>()
                .ForMember(x => x.MapUrl, opt => opt.MapFrom(x => x.Map.UrlPath));
        }
    }
}