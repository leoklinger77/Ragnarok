using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_PositionName")]
    public class PositionName
    {
        public int Id { get; set; }
        [Display(Name = "Nome do Cargo")]
        public string Name { get; set; }
        [Display(Name = "Cadastro")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Business Business { get; set; }
        public int BusinessId { get; set; }
        
        public ICollection<Employee> Employee { get; set; } = new HashSet<Employee>();

        public PositionName()
        {
        }

        public PositionName(int id, string name, DateTime insertDate, DateTime? updateDate, Business business)
        {
            Id = id;
            Name = name;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            Business = business;
        }

        public override bool Equals(object obj)
        {
            return obj is PositionName name &&
                   Id == name.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
        public int ToalEmployees()
        {
            return Employee.Count;
        }
    }
}
