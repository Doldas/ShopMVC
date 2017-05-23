using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Resopitory
{
    public class ItemResopitory : StockItem
    {
        private DataAccess.ItemStorageContext db;

        public ItemResopitory()
        {
            db = new DataAccess.ItemStorageContext();
        }
        public List<StockItem> GetAll()
        {
            return db.Items.ToList();
        }
    }
}