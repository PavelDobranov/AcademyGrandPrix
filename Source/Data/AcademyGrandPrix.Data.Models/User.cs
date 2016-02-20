namespace AcademyGrandPrix.Data.Models
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using AcademyGrandPrix.Data.Common.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    public class User : IdentityUser, IDeletableEntity, IAuditInfo
    {
        public User()
        {
            this.CreatedOn = DateTime.Now;
        }

        public int AvatarId { get; set; }

        [ForeignKey("AvatarId")]
        public virtual Image Avatar { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

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
