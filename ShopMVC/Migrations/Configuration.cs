namespace ShopMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopMVC.DataAccess.ItemStorageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopMVC.DataAccess.ItemStorageContext context)
        {
            context.Items.AddOrUpdate(item=>item.ID,
            new Models.StockItem
            {
                ID=context.Items.Count(),
                Name="Healing Potion IV",
                Description="A Healing Potion",
                Category=Models.ItemCategory.Potion,
                Price=129,
                Quantity=6,
                ShelfPosition="Health Self",
                ArticleNumber="#001-001"
            },
            new Models.StockItem
            {
                ID = context.Items.Count(),
                Name = "God Potion I",
                Description = "A potion that gives you god like powers",
                Category = Models.ItemCategory.Potion,
                Price = 679,
                Quantity = 2,
                ShelfPosition = "Secret Self",
                ArticleNumber = "#000-001"
            },
            new Models.StockItem
            {
                ID = context.Items.Count(),
                Name = "Unicorn(White)",
                Description = "A Magical Unicorn",
                Category = Models.ItemCategory.Mythical_Creatures,
                Price = 5876,
                Quantity = 2,
                ShelfPosition = "Animal Self",
                ArticleNumber = "#002-001"
            },
            new Models.StockItem
            {
                ID = context.Items.Count(),
                Name = "Unicorn(Black)",
                Description = "A Magical Unicorn",
                Category = Models.ItemCategory.Mythical_Creatures,
                Price = 11879,
                Quantity = 2,
                ShelfPosition = "Animal Self",
                ArticleNumber = "#002-002"
            }
            );
        }
    }
}
