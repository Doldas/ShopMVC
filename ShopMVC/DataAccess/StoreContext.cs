using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopMVC.DataAccess
{
    public class StoreContext : DbContext
    {
        public DbSet<Models.StockItem> Items { get; set; }
        public StoreContext() : base("DefaultConnection") { }
    }
}