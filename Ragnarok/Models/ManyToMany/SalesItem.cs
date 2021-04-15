using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models.ManyToMany
{
    [Table("TB_SalesItem")]
    public class SalesItem
    {
        public SalesOrder SalesOrder { get; set; }
        public int SalesOrderId { get; set; }
        public Stock Stock { get; set; }
        public int StockId { get; set; }
        
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }

        public SalesItem()
        {
        }

        public SalesItem(SalesOrder salesOrder, Stock stock, int quantity, double price, double discount)
        {
            SalesOrder = salesOrder;
            Stock = stock;
            Quantity = quantity;
            Price = price;
            Discount = discount;
        }
        public override bool Equals(object obj)
        {
            return obj is SalesItem item &&
                   SalesOrderId == item.SalesOrderId &&
                   StockId == item.StockId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SalesOrderId, StockId);
        }
        public double Total()
        {
            return (Quantity * Price) - Discount;
        }
    }
}
