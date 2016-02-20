namespace AcademyGrandPrix.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AcademyGrandPrix.Data.Common.Models;

    public class Rating : BaseModel<int>
    {
        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int TrackId { get; set; }

        [ForeignKey("TrackId")]
        public virtual Track Track { get; set; }
    }
}
