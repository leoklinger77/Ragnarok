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
        public double Value { get; set; }
        public int Quantity { get; set; }
        public DateTime ValidationDate { get; set; }

        public PurchaseItemOrder()
        {
        }

        public PurchaseItemOrder(Product product, PurchaseOrder purchaseOrder, double value, int quantity, DateTime validationDate)
        {
            Product = product;
            PurchaseOrder = purchaseOrder;
            Value = value;
            Quantity = quantity;
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
        public double Total()
        {
            return Value * Quantity;
        }
    }
}
