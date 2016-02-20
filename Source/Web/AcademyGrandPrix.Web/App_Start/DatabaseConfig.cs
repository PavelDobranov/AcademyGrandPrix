namespace AcademyGrandPrix.Web
{
    using System.Data.Entity;

    using AcademyGrandPrix.Data;
    using AcademyGrandPrix.Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AcademyGrandPrixDbContext, Configuration>(true));
            AcademyGrandPrixDbContext.Create().Database.Initialize(true);
        }
    }
}