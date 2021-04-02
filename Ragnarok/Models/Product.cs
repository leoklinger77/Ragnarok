using Ragnarok.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_Product")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Employee RegisterEmployee { get; set; }
        public int RegisterEmployeeId { get; set; }
        public ICollection<CategoryProduct> CategoryProduct { get; set; } = new HashSet<CategoryProduct>();

        public Product()
        {
        }

        public Product(int id, string name, string barCode, DateTime insertDate, DateTime? updateDate, Employee registerEmployee)
        {
            Id = id;
            Name = name;
            BarCode = barCode;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            RegisterEmployee = registerEmployee;
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Id == product.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
