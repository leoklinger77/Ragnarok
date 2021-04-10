using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_Stock")]
    public class Stock
    {
        public int Id { get; set; }
        public int Quantity { get; private set; }        
        public DateTime? ValidationDate { get; set; }
        public double SalesPrice { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Stock()
        {
        }

        public Stock(int id, int quantity, DateTime? validationDate, double salesPrice, DateTime insertDate, DateTime? updateDate, Product product)
        {
            Id = id;
            Quantity = quantity;
            ValidationDate = validationDate;
            SalesPrice = salesPrice;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            Product = product;
        }

        public override bool Equals(object obj)
        {
            return obj is Stock stock &&
                   Id == stock.Id &&
                   EqualityComparer<Product>.Default.Equals(Product, stock.Product);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Product);
        }
        public void AddQuantityStock(int quantity)
        {
            Quantity += quantity;
        }
        public void RemoveQuantityStock(int quantity)
        {
            Quantity -= quantity;
        }

    }
}
