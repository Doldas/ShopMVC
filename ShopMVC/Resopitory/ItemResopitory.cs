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

        public List<StockItem> GetAll(string sortMethod, bool descending)
        {
            sortMethod = sortMethod.ToLower();
            if(sortMethod=="name")
            {
                if (descending == false)
                {
                    return db.Items.OrderBy(item => item.Name).ToList();
                }
                else if(descending)
                {
                    return db.Items.OrderByDescending(item => item.Name).ToList();
                }
            }
            else if(sortMethod=="price")
            {
                if (descending == false)
                {
                    return db.Items.OrderBy(item => item.Price).ToList();
                }
                else if (descending)
                {
                    return db.Items.OrderByDescending(item => item.Price).ToList();
                }
            }
            else if (sortMethod == "category")
            {
                if (descending == false)
                {
                    return db.Items.OrderBy(item => item.Category).ToList();
                }
                else if (descending)
                {
                    return db.Items.OrderByDescending(item => item.Category).ToList();
                }
            }
            return db.Items.ToList(); //Non Sorted List
        }
        public List<StockItem> Search(string searchTerm)
        {
            return db.Items.Where(item => item.Name.Contains(searchTerm)||item.ArticleNumber.Contains(searchTerm)).ToList();
        }

        public void Edit(StockItem item)
        {
            //Default values if null
            if (item.Name == null)
            {
                item.Name = db.Items.Where(i => i.ID == item.ID).First().Name;
            }
            if(item.Price==0)
            {
                item.Price = db.Items.Where(i => i.ID == item.ID).First().Price;
            }
            if(item.Description==null)
            {
                item.Description = db.Items.Where(i => i.ID == item.ID).First().Description;
            }
            if(item.ArticleNumber==null)
            {
                item.ArticleNumber = db.Items.Where(i => i.ID == item.ID).First().ArticleNumber;
            }
            if(item.ShelfPosition==null)
            {
                item.ShelfPosition = db.Items.Where(i => i.ID == item.ID).First().ShelfPosition;
            }
            //Removes the Existing and than added it to the table again.
            //I don't know how to update an item inside a table yet. 
            
            // Sql Code - Update from StockItems set Name='item.Name' where ID=item.ID
            // A Good question is how do I Update a column instead of removing and adding it?

            db.Items.Remove(db.Items.Where(i=>i.ID==item.ID).First());
            db.Items.Add(item);
            //Saves the new Data in the Database
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