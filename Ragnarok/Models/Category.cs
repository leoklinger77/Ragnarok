using Ragnarok.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_Category")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Employee RegisterEmployee { get; set; }
        public int RegisterEmployeeId { get; set; }
        public ICollection<CategoryProduct> CategoryProduct { get; set; }

        public Category()
        {
        }

        public Category(int id, string name, DateTime insertDate, DateTime? updateDate, Employee registerEmployee)
        {
            Id = id;
            Name = name;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            RegisterEmployee = registerEmployee;
        }

        public override bool Equals(object obj)
        {
            return obj is Category category &&
                   Id == category.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
