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
        public Employee RegisterEmployee { get; set; }
        public int RegisterEmployeeId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public ICollection<SalesItem> SalesItem { get; set; } = new List<SalesItem>();

        public SalesOrder()
        {
        }

        public SalesOrder(int id, string notes, Client client, Employee registerEmployee, DateTime insertDate, DateTime? updateDate, ICollection<SalesItem> salesItem)
        {
            Id = id;
            Notes = notes;
            Client = client;
            RegisterEmployee = registerEmployee;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            SalesItem = salesItem;
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
