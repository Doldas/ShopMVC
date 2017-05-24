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
        public StockItem GetItem(int id)
        {
            return db.Items.Where(item=>item.ID==id).FirstOrDefault();
        }
        public StockItem GetItem(string article)
        {
            return db.Items.Where(item=>item.ArticleNumber==ArticleNumber).FirstOrDefault();
        }
        public List<StockItem> GetAll()
        {
            return db.Items.ToList();
        }
        public void Edit(StockItem item)
        {
            db.Items.Remove(db.Items.Where(i=>i.ID==item.ID).First());
            db.Items.Add(item);
            db.SaveChanges();
        }
        public void Add(StockItem item)
        {
            db.Items.Add(item);
            db.SaveChanges();
        }
        public void Add(string article,string name,string description,string shelf,Models.ItemCategory category,double price ,int quantity)
        {
            db.Items.Add(
                new StockItem
                {
                    ArticleNumber=article,
                    Name=name,
                    Description=description,
                    ShelfPosition=shelf,
                    Category=category,
                    Price=price,
                    Quantity=quantity
                }
            );
            db.SaveChanges();
        }
        public void Delete(int id)
        {
                db.Items.Remove(db.Items.Where(i => i.ID == id).FirstOrDefault());
                db.SaveChanges();
        }
    }
}