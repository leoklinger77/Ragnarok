using Ragnarok.Services.Lang;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_SupplierPhysical")]
    public class SupplierPhysical : Supplier
    {
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = ("MSG_E_002"))]
        public string FullName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = ("MSG_E_002"))]
        public string FantasyName { get; set; }        
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = ("MSG_E_002"))]
        public DateTime OpeningDate { get; set; }
        
        private string _cpf;

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = ("MSG_E_002"))]        
        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value.Replace(".", "").Replace("-", ""); }
        }

        public SupplierPhysical()
        {
        }

        public SupplierPhysical(string fullName, string fantasyName, DateTime openingDate, string cPF,
            int id, DateTime insertDate, DateTime? updateDate, Address address, Employee registerEmployee)
            : base(id, insertDate, updateDate, address, registerEmployee)
        {
            FullName = fullName;
            FantasyName = fantasyName;
            OpeningDate = openingDate;
            CPF = cPF;
        }
        public override bool Equals(object obj)
        {
            return obj is SupplierPhysical physical &&
                   id == physical.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }

        public override int Age()
        {
            int age = DateTime.Now.Year - OpeningDate.Year;

            if (DateTime.Now.DayOfWeek < OpeningDate.DayOfWeek)
            {
                age += 1;
            }
            return age;
        }

        public override int RegisteredTime()
        {
            int temp = DateTime.Now.Year - InsertDate.Year;

            if (DateTime.Now.DayOfWeek < InsertDate.DayOfWeek)
            {
                temp += 1;
            }
            return temp;
        }


    }
}
