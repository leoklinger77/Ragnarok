using Ragnarok.Services.Lang;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_Supplierjuridical")]
    public class SupplierJuridical : Supplier
    {
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public string FullName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public DateTime OpeningDate { get; set; }
        private string _cnpj;

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public string CNPJ
        {
            get { return _cnpj; }
            set { _cnpj = value.Replace(".", "").Replace("-", ""); }
        }

        public SupplierJuridical()
        {
        }

        public SupplierJuridical(int id, string email, DateTime insertDate, DateTime? updateDate, Address address, Employee registerEmployee,
            string fullName, DateTime openingDate, string cNPJ)
            : base(id, email, insertDate, updateDate, address, registerEmployee)
        {
            FullName = fullName;
            OpeningDate = openingDate;
            CNPJ = cNPJ;
        }

        public override bool Equals(object obj)
        {
            return obj is SupplierJuridical supplierjuridical &&
                   Id == supplierjuridical.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
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
