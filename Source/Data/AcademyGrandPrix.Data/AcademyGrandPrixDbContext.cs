namespace AcademyGrandPrix.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using AcademyGrandPrix.Data.Models;
    
    public class AcademyGrandPrixDbContext : IdentityDbContext<User>
    {
        public AcademyGrandPrixDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static AcademyGrandPrixDbContext Create()
        {
            return new AcademyGrandPrixDbContext();
        }
    }
}
