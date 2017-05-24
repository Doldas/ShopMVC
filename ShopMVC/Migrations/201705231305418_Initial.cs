namespace ShopMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ArticleNumber = c.String(),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        ShelfPosition = c.String(),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        Category=c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockItems");
        }
    }
}
