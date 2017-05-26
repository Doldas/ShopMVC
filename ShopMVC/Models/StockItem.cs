using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    public enum ItemCategory
    {
        Potion,
        Scroll,
        Spell,
        Book,
        Mythical_Creatures
    }
    public class StockItem
    {
        //Primary key
        [Key]
        public int ID { get; set; }
        //Proporties
        [StringLength(8)]
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        [Range(1,12000)] 
        public double Price { get; set; }
        public string ShelfPosition { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public ItemCategory Category { get; set; } 
    }
}