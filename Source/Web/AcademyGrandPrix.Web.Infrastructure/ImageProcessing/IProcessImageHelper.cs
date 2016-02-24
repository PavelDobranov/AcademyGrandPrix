namespace AcademyGrandPrix.Web.Infrastructure.ImageProcessing
{
    using System.Web;

    public interface IProcessImageHelper
    {
        byte[] ProcessImage(HttpPostedFileBase rawImage);
    }
}
