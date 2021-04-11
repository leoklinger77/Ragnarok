using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models.ManyToMany
{
    [Table("TB_DiscontStock")]
    public class DiscountProductStock
    {
        public Stock Stock { get; set; }
        public int StockId { get; set; }
        public DiscountStock DiscountProduct { get; set; }
        public int DiscountProductId { get; set; }



        public DiscountProductStock()
        {
        }

        public DiscountProductStock(DiscountStock discountProduct, Stock stock)
        {
            DiscountProduct = discountProduct;
            Stock = stock;
        }
    }
}
