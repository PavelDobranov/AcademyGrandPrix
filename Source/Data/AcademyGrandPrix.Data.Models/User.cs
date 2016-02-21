namespace AcademyGrandPrix.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using AcademyGrandPrix.Data.Common.Models;

    public class User : IdentityUser, IDeletableEntity, IAuditInfo
    {
        private ICollection<Vote> votes;

        public User()
        {
            this.votes = new HashSet<Vote>();
            this.CreatedOn = DateTime.Now;
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            //// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            //// Add custom user claims here
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            //// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            //// Add custom user claims here
            return userIdentity;
        }
    }
}
