using Ragnarok.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_SalesOrder")]
    public class SalesOrder
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }

        public SaleBox SaleBox { get; set; }
        public int SaleBoxId { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public ICollection<SalesItem> SalesItem { get; set; } = new List<SalesItem>();

        public SalesOrder()
        {
        }

        public SalesOrder(int id, string notes, Client client, SaleBox saleBox, DateTime insertDate, DateTime? updateDate, ICollection<SalesItem> salesItem)
        {
            Id = id;
            Notes = notes;
            Client = client;
            SaleBox = saleBox;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            SalesItem = salesItem;
        }
        public override bool Equals(object obj)
        {
            return obj is SalesOrder order &&
                   Id == order.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public double TotalSales()
        {
            double sum = 0;
            foreach (var item in SalesItem)
            {
                sum += item.Total();
            }
            return sum;
        }
    }
}
