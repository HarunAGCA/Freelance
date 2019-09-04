namespace Freelance.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        OfferPrice = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        MaxPrice = c.Int(nullable: false),
                        ReleaseTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DeadlineTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        OwnerId = c.Int(nullable: false),
                        WorkerId = c.Int(),
                        IsCompletedOwner = c.Boolean(nullable: false),
                        IsCompletedWorker = c.Boolean(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Credit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        AcceptedPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateString = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Offers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Offers", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Payments", new[] { "ProjectId" });
            DropIndex("dbo.Offers", new[] { "ProjectId" });
            DropIndex("dbo.Offers", new[] { "UserId" });
            DropTable("dbo.States");
            DropTable("dbo.Payments");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
            DropTable("dbo.Offers");
            DropTable("dbo.Messages");
        }
    }
}
