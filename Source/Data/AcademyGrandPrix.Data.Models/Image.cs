namespace AcademyGrandPrix.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OriginalFileName { get; set; }

        [Required]
        public string FileExtension { get; set; }

        [Required]
        public string UrlPath { get; set; }
    }
}
