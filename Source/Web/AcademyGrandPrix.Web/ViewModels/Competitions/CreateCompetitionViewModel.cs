namespace AcademyGrandPrix.Web.ViewModels.Competitions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AcademyGrandPrix.Data.Models;
    using AcademyGrandPrix.Web.Infrastructure.Mappings.Contracts;

    public class CreateCompetitionViewModel : IMapFrom<Competition>
    {
        [Display(Name = "Competition Track")]
        [UIHint("AgpDropDownList")]
        public int TrackId { get; set; }
        
        [Display(Name = "Competition Type")]
        [UIHint("AgpEnum")]
        public CompetitionType Type { get; set; }

        [Display(Name = "Is Public")]
        [UIHint("AgpBool")]
        public bool IsPublic { get; set; }

        [Display(Name = "Number Of Laps")]
        [UIHint("AgpInteger")]
        public int LapsCount { get; set; }

        [Display(Name = "Start Date And Time")]
        [UIHint("AgpDateTime")]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "End Date And Time")]
        [UIHint("AgpDateTime")]
        public DateTime EndDateTime { get; set; }

        public IEnumerable<SelectListItem> Tracks { get; set; }
    }
}