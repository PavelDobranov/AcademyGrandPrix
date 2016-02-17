namespace AcademyGrandPrix.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AcademyGrandPrix.Data.Common.Models;

    public class Track : BaseModel<int>
    {
        private ICollection<Image> photos;

        public Track()
        {
            this.photos = new HashSet<Image>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Length { get; set; }

        public TrackDifficultyType Difficulty { get; set; }

        public virtual int MapId { get; set; }

        [ForeignKey("MapId")]
        public virtual Image Map { get; set; }

        public virtual ICollection<Image> Photos
        {
            get { return this.photos; }
            set { this.photos = value; }
        }
    }
}
