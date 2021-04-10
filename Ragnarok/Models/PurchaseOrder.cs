using Ragnarok.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_PurchaseOrder")]
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public string Notes { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
        public Employee RegisterEmployee { get; set; }
        public int RegisterEmployeeId { get; set; }

        public ICollection<PurchaseItemOrder> PurchaseItemOrder { get; set; } = new List<PurchaseItemOrder>();

        public PurchaseOrder()
        {
        }

        public PurchaseOrder(int id, DateTime insertDate, string notes, Supplier supplier, Employee registerEmployee, ICollection<PurchaseItemOrder> purchaseItemOrder)
        {
            Id = id;
            InsertDate = insertDate;
            Notes = notes;
            Supplier = supplier;
            RegisterEmployee = registerEmployee;
            PurchaseItemOrder = purchaseItemOrder;
        }

        public double Total()
        {
            double sum = 0.0;
            foreach (var item in PurchaseItemOrder)
            {
                sum += item.TotalPurchase();
            }
            return sum;
        }

        public double TotalPurchase()
        {
            double sum = 0.0;
            foreach (var item in PurchaseItemOrder)
            {
                sum += item.TotalDiscontPurchase();
            }
            return sum;
        }
        public double TotalDiscont()
        {
            double sum = 0.0;
            foreach (var item in PurchaseItemOrder)
            {
                sum += item.Discount;
            }
            return sum;
        }
    }
}
