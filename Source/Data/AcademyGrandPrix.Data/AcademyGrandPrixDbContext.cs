namespace AcademyGrandPrix.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using AcademyGrandPrix.Data.Models;
    using AcademyGrandPrix.Data.Common.Models;

    public class AcademyGrandPrixDbContext : IdentityDbContext<User>
    {
        public AcademyGrandPrixDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Track> Tracks { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public static AcademyGrandPrixDbContext Create()
        {
            return new AcademyGrandPrixDbContext();
        }
        
        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in this.ChangeTracker.Entries()
                    .Where(e => e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }
    }
}
