namespace PropertyAgency.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilePathAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
            DropColumn("dbo.Properties", "UrlPicture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "UrlPicture", c => c.String());
            DropForeignKey("dbo.FilePaths", "PropertyId", "dbo.Properties");
            DropIndex("dbo.FilePaths", new[] { "PropertyId" });
            DropTable("dbo.FilePaths");
        }
    }
}
