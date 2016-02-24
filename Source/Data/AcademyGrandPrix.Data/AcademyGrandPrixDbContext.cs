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

        public virtual IDbSet<Competition> Competitions { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Vote> Votes { get; set; }

        public static AcademyGrandPrixDbContext Create()
        {
            return new AcademyGrandPrixDbContext();
        }

        private void ApplyAuditInfoRules()
        {
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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Vote>()
        //        .HasRequired(c => c.Track)
        //        .WithMany()
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Vote>()
        //        .HasRequired(c => c.Author)
        //        .WithMany()
        //        .WillCascadeOnDelete(false);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
