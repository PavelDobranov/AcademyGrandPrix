namespace AcademyGrandPrix.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AcademyGrandPrix.Data.Common.Models;

    public class Track : BaseModel<int>
    {
        private ICollection<Vote> votes;
        private ICollection<Competition> competitions;

        public Track()
        {
            this.votes = new HashSet<Vote>();
            this.competitions = new HashSet<Competition>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Length { get; set; }

        public TrackDifficultyType Difficulty { get; set; }

        public int? MapId { get; set; }

        [ForeignKey("MapId")]
        public virtual Image Map { get; set; }
        
        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ICollection<Competition> Competitions
        {
            get { return this.competitions; }
            set { this.competitions = value; }
        }
    }
}
