namespace AcademyGrandPrix.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum CompetitionType
    {
        [Display(Name = "Time Trail")]
        TimeTrail = 0,
        Competetive = 1
    }
}
