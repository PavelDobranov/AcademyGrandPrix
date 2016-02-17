namespace AcademyGrandPrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TracksAndImagesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginalFileName = c.String(nullable: false),
                        FileExtension = c.String(nullable: false),
                        UrlPath = c.String(nullable: false),
                        Track_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tracks", t => t.Track_Id)
                .Index(t => t.Track_Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Length = c.Double(nullable: false),
                        Difficulty = c.Int(nullable: false),
                        MapId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.MapId, cascadeDelete: true)
                .Index(t => t.MapId)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.Tracks", "MapId", "dbo.Images");
            DropIndex("dbo.Tracks", new[] { "IsDeleted" });
            DropIndex("dbo.Tracks", new[] { "MapId" });
            DropIndex("dbo.Images", new[] { "Track_Id" });
            DropTable("dbo.Tracks");
            DropTable("dbo.Images");
        }
    }
}
