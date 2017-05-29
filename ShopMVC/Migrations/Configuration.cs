namespace ShopMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopMVC.DataAccess.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopMVC.DataAccess.StoreContext context)
        {
                        context.Items.AddOrUpdate(
            new Models.StockItem
            {
                ID = 0,
                Name = "Healing Potion IV",
                Description = "A Healing Potion",
                Category = Models.ItemCategory.Potion,
                Price = 129,
                Quantity = 6,
                ShelfPosition = "Health Self",
                ArticleNumber = "#001-001"
            },
            new Models.StockItem
            {
                ID = 1,
                Name = "God Potion I",
                Description = "A potion that gives you god like powers",
                Category = Models.ItemCategory.Potion,
                Price = 679,
                Quantity = 2,
                ShelfPosition = "Secret Self",
                ArticleNumber = "#003-001"
            },
            new Models.StockItem
            {
                ID = 2,
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
                ID = 3,
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
