namespace AcademyGrandPrix.Data.Models
{
    using AcademyGrandPrix.Data.Common.Models;

    using System.ComponentModel.DataAnnotations;

    public class Image : BaseModel<int>
    {
        [Required]
        public byte[] Content { get; set; }

        [Required]
        public string FileExtension { get; set; }
    }
}
