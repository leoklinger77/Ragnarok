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
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
        public Employee RegisterEmployee { get; set; }
        public int RegisterEmployeeId { get; set; }

        public ICollection<PurchaseItemOrder> PurchaseItemOrder { get; set; } = new List<PurchaseItemOrder>();

        public PurchaseOrder()
        {
        }

        public PurchaseOrder(int id, DateTime insertDate, Supplier supplier, Employee employee)
        {
            Id = id;
            InsertDate = insertDate;
            Supplier = supplier;
            RegisterEmployee = employee;
        }

        public double TotalPurchase()
        {
            double sum = 0.0;
            foreach (var item in PurchaseItemOrder)
            {
                sum += item.Total();
            }
            return sum;
        }
    }
}
