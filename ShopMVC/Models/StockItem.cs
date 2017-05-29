using System.ComponentModel.DataAnnotations;

namespace ShopMVC.Models
{
    #region Enum
    //Category
    public enum ItemCategory
    {
        Potion,
        Scroll,
        Spell,
        Book,
        Mythical_Creatures
    }
    #endregion

    public class StockItem
    {
        #region Proporties
        //Primary key
        [Key]
        public int ID { get; set; }
        //All other properties
        [Required]
        [StringLength(8)]
        public string ArticleNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,12000)] 
        public double Price { get; set; }

        public string ShelfPosition { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public ItemCategory Category { get; set; }
        #endregion
    }
}