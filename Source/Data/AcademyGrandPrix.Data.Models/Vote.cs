namespace AcademyGrandPrix.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AcademyGrandPrix.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int TrackId { get; set; }

        public virtual Track Track { get; set; }

        public int Value { get; set; }
    }
}
