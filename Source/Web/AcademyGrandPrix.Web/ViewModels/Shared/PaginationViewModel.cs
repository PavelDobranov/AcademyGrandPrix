namespace AcademyGrandPrix.Web.ViewModels.Shared
{
    public class PaginationViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public string Url { get; set; }
    }
}