namespace AcademyGrandPrix.Web.Infrastructure.ImageProcessing
{
    using System.IO;
    using System.Web;

    public class ProcessImageHelper : IProcessImageHelper
    {
        public byte[] ProcessImage(HttpPostedFileBase rawImage)
        {
            byte[] content;

            using (var memory = new MemoryStream())
            {
                rawImage.InputStream.CopyTo(memory);
                content = memory.GetBuffer();
            }

            return content;
        }
    }
}
