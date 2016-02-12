using Microsoft.AspNet.Identity.EntityFramework;
using AcademyGrandPrix.Data.Models;

namespace AcademyGrandPrix.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}