namespace AcademyGrandPrix.Web.Infrastructure.Populators
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public interface ITracksPopulator
    {
        IEnumerable<SelectListItem> GetData();
    }
}
