using AcademyGrandPrix.Data.Models;
using AcademyGrandPrix.Web.Infrastructure.Mappings.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcademyGrandPrix.Web.ViewModels.Tracks
{
    public class CreateTrackViewModel : IMapFrom<Track>
    {
        [UIHint("AgpSingleLineText")]
        public string Name { get; set; }

        [UIHint("AgpNumber")]
        public double Length { get; set; }

        [UIHint("AgpEnum")]
        public TrackDifficultyType Difficulty { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }
    }
}