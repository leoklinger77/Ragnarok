using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_PurchaseItemOrder")]
    public class PurchaseItemOrder
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public int PurchaseOrderId { get; set; }
        public double PurchasePrice { get; set; }
        public double SalesPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public DateTime? ValidationDate { get; set; }

        public PurchaseItemOrder()
        {
        }

        public PurchaseItemOrder(Product product, PurchaseOrder purchaseOrder, double purchasePrice, double salesPrice, int quantity, double discount, DateTime? validationDate)
        {
            Product = product;
            PurchaseOrder = purchaseOrder;
            PurchasePrice = purchasePrice;
            SalesPrice = salesPrice;
            Quantity = quantity;
            Discount = discount;
            ValidationDate = validationDate;
        }

        public override bool Equals(object obj)
        {
            return obj is PurchaseItemOrder order &&
                   EqualityComparer<Product>.Default.Equals(Product, order.Product) &&
                   EqualityComparer<PurchaseOrder>.Default.Equals(PurchaseOrder, order.PurchaseOrder);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Product, PurchaseOrder);
        }
        public double TotalPurchase()
        {
            return (PurchasePrice * Quantity);
        }
        public double TotalDiscontPurchase()
        {
            return (PurchasePrice * Quantity) - Discount;
        }
        public double TotalSales()
        {
            return (SalesPrice * Quantity);
        }
    }
}
