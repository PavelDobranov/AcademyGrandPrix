namespace AcademyGrandPrix.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AcademyGrandPrix.Data.Common.Models;

    public class Track : BaseModel<int>
    {
        private ICollection<Image> photos;
        private ICollection<Vote> votes;

        public Track()
        {
            this.photos = new HashSet<Image>();
            this.votes = new HashSet<Vote>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Length { get; set; }

        public TrackDifficultyType Difficulty { get; set; }

        public int MapId { get; set; }

        [ForeignKey("MapId")]
        public virtual Image Map { get; set; }

        public virtual ICollection<Image> Photos
        {
            get { return this.photos; }
            set { this.photos = value; }
        }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
