namespace AssignmentFPTBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialRun : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50, unicode: false),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Phone = c.String(nullable: false, unicode: false),
                        Address = c.String(nullable: false, maxLength: 200, unicode: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50, unicode: false),
                        ContentFeedback = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => new { t.Username, t.ContentFeedback })
                .ForeignKey("dbo.Accounts", t => t.Username)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 13, unicode: false),
                        Address = c.String(nullable: false, maxLength: 100, unicode: false),
                        OrderDate = c.DateTime(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Accounts", t => t.Username)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        BookID = c.String(nullable: false, maxLength: 10, unicode: false),
                        Quantity = c.Int(nullable: false),
                        AmountPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.BookID })
                .ForeignKey("dbo.Books", t => t.BookID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.OrderID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.String(nullable: false, maxLength: 10, unicode: false),
                        BookName = c.String(nullable: false, maxLength: 100),
                        CategoryID = c.String(nullable: false, maxLength: 10, unicode: false),
                        AuthorID = c.String(nullable: false, maxLength: 10, unicode: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Image = c.String(nullable: false, maxLength: 500, unicode: false),
                        ShortDesc = c.String(nullable: false, maxLength: 200),
                        DetailDesc = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Authors", t => t.AuthorID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.String(nullable: false, maxLength: 10, unicode: false),
                        AuthorName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.String(nullable: false, maxLength: 10, unicode: false),
                        CategoryName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Username", "dbo.Accounts");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Books", "AuthorID", "dbo.Authors");
            DropForeignKey("dbo.Feedbacks", "Username", "dbo.Accounts");
            DropIndex("dbo.Books", new[] { "AuthorID" });
            DropIndex("dbo.Books", new[] { "CategoryID" });
            DropIndex("dbo.OrderDetails", new[] { "BookID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "Username" });
            DropIndex("dbo.Feedbacks", new[] { "Username" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Category");
            DropTable("dbo.Authors");
            DropTable("dbo.Books");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Accounts");
        }
    }
}
