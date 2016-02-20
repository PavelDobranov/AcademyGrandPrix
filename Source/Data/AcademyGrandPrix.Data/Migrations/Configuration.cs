namespace AcademyGrandPrix.Data.Migrations
{
    using System.Linq;
    using System.Data.Entity.Migrations;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    using AcademyGrandPrix.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<AcademyGrandPrixDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AcademyGrandPrixDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = "123456";

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Administrator" };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, "Administrator");
            }

            if (!context.Images.Any())
            {
                var image = new Image
                {
                    FileExtension = ".jpeg",
                    OriginalFileName = "track_name",
                    UrlPath = "http://10-themes.com/data_images/wallpapers/30/394976-track.jpg"
                };

                context.Images.Add(image);
                context.SaveChanges();
            }

            if (!context.Tracks.Any())
            {
                var map = context.Images.FirstOrDefault();

                for (int i = 0; i < 10; i++)
                {
                    var track = new Track
                    {
                        Length = i + 1,
                        Name = "Track Name" + i,
                        Map = map,
                        Difficulty = TrackDifficultyType.Expert
                    };

                    context.Tracks.Add(track);
                }
            }

            context.SaveChanges();
        }
    }
}
