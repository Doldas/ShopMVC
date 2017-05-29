using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopMVC.Resopitory
{
    public class ItemRepository : StockItem
    {
        private DataAccess.StoreContext db;

        public ItemRepository()
        {
            db = new DataAccess.StoreContext();
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

        public List<StockItem> GetAll(string sortMethod, bool descending, string search="")
        {
            sortMethod = sortMethod.ToLower();
            if(sortMethod=="articlenumber")
            {
                if (descending == false)
                {
                    return Search(search).OrderBy(item => item.ArticleNumber).ToList();
                }
                else if(descending)
                {
                    return Search(search).OrderByDescending(item => item.ArticleNumber).ToList();
                }
            }
            else if(sortMethod=="shelfposition")
            {
                if (descending == false)
                {
                    return Search(search).OrderBy(item => item.ShelfPosition).ToList();
                }
                else if (descending)
                {
                    return Search(search).OrderByDescending(item => item.ShelfPosition).ToList();
                }
            }
            else if (sortMethod == "quantity")
            {
                if (descending == false)
                {
                    return Search(search).OrderBy(item => item.Quantity).ToList();
                }
                else if (descending)
                {
                    return Search(search).OrderByDescending(item => item.Quantity).ToList();
                }
            }
            return db.Items.ToList(); //Non Sorted List
        }
        public List<StockItem> Search(string searchTerm)
        {
            double number = -1; //double number have a default value as -1.00 , just so that we won't have any null values

            //Try to parse the input string to double, if it works, the user want to search for price
            try
            {
                number = double.Parse(searchTerm);
            }
            catch //If the parse didin't work it might be a name, category or article number so return a list containing either of those
            {
                return db.Items.Where(item => item.Name.Contains(searchTerm) || item.ArticleNumber == searchTerm || item.Category.ToString().Contains(searchTerm)).ToList();
            }
            return db.Items.Where(item => item.Price == number).ToList(); //try succeeded so let's return a list based on price
        }

        public void Edit(StockItem item)
        {
            //Edits the element without removing and inserting it
            db.Entry(item).State = EntityState.Modified; 
            //Saves the new Data in the Database
            db.SaveChanges();
        }
        public void Add(StockItem item)
        {
            item.ID = db.Items.Count();
            db.Items.Add(item);
            db.SaveChanges();
        }
        public void Add(string article,string name,string description,string shelf,Models.ItemCategory category,double price ,int quantity)
        {
            db.Items.Add(
                new StockItem
                {
                    ID=db.Items.Count(),
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