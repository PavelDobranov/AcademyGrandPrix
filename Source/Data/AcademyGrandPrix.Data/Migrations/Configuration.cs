namespace AcademyGrandPrix.Data.Migrations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
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
            const string AdministratorUserName = "admin@agp.com";
            const string AdministratorPassword = "123456";

            var rnd = new Random();

            var seededUsers = new List<User>();
            var seededTracks = new List<Track>();

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
                var admin = new User { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(admin, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(admin.Id, "Administrator");

                // Seed regular users
                for (int i = 1; i <= 20; i++)
                {
                    string userName = string.Format("user{0}@agp.com", i);
                    string userPassword = "123456";
                    var user = new User { UserName = userName, Email = userName };

                    userManager.Create(user, userPassword);
                    seededUsers.Add(user);
                }
            }

            if (!context.Images.Any())
            {
                var image = new Image
                {
                    FileExtension = ".jpeg",
                    OriginalFileName = "track_name",
                    UrlPath = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/BTCC_Brands06_PaddockHill.jpg/1024px-BTCC_Brands06_PaddockHill.jpg"
                };

                context.Images.Add(image);
                context.SaveChanges();
            }

            if (!context.Tracks.Any())
            {
                var map = context.Images.FirstOrDefault();

                for (int i = 1; i <= 30; i++)
                {
                    var track = new Track
                    {
                        Length = i + 1,
                        Name = "Track Name" + i,
                        Map = map,
                        Difficulty = TrackDifficultyType.Expert
                    };

                    context.Tracks.Add(track);
                    seededTracks.Add(track);
                }

                context.SaveChanges();
            }

            if (!context.Votes.Any())
            {
                for (int i = 1; i < 1000; i++)
                {
                    var vote = new Vote
                    {
                        AuthorId = seededUsers[rnd.Next(0, seededUsers.Count)].Id,
                        TrackId = seededTracks[rnd.Next(0, seededTracks.Count)].Id,
                        Value = rnd.Next(1, 6)
                    };

                    context.Votes.Add(vote);

                    if (i % 100 == 0)
                    {
                        context.SaveChanges();
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
