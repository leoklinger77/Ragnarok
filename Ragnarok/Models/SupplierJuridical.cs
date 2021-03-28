using Ragnarok.Services.Lang;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_Supplierjuridical")]
    public class SupplierJuridical : Supplier
    {
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = ("MSG_E_002"))]
        public string FullName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = ("MSG_E_002"))]
        public DateTime BirthDay { get; set; }
        private string _cpf;

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = ("MSG_E_002"))]
        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value.Replace(".", "").Replace("-", ""); }
        }

        public SupplierJuridical()
        {
        }

        public SupplierJuridical(string fullName, DateTime birthDay, string cPF,
            int id, DateTime insertDate, DateTime? updateDate, Address address, Employee registerEmployee)
            : base(id, insertDate, updateDate, address, registerEmployee)
        {
            FullName = fullName;
            BirthDay = birthDay;
            CPF = cPF;
        }
        public override bool Equals(object obj)
        {
            return obj is SupplierJuridical supplierjuridical &&
                   id == supplierjuridical.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }

        public override int Age()
        {
            int age = DateTime.Now.Year - BirthDay.Year;

            if (DateTime.Now.DayOfWeek < BirthDay.DayOfWeek)
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
