namespace AcademyGrandPrix.Services.Web.Contracts
{
    public interface IIdentifierProvider
    {
        int DecodeId(string urlId);

        string EncodeId(int id);
    }
}
