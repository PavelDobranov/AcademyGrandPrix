namespace AcademyGrandPrix.Web.ViewModels.Votes
{
    using System.ComponentModel.DataAnnotations;

    public class CreateVoteInputModel
    {
        [Required]
        public string AuthorId { get; set; }

        public int TrackId { get; set; }

        public int Value { get; set; }
    }
}