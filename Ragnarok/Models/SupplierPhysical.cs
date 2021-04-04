using Ragnarok.Models.Enums;
using Ragnarok.Services.Lang;
using Ragnarok.Services.Validation.Supplier;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_SupplierPhysical")]
    public class SupplierPhysical : Supplier
    {
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public string FullName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public DateTime BirthDay { get; set; }
        public Sexo Sexo { get; set; }

        private string _cpf;

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        [CPFValidationSupplier]
        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value.Replace(".", "").Replace("-", ""); }
        }

        public SupplierPhysical() : base()
        {
        }

        public SupplierPhysical(int id, string email, bool active, DateTime insertDate, DateTime? updateDate, Address address, Employee registerEmployee,
            string fullName, DateTime birthDay, Sexo sexo, string cPF)
            : base(id, email, active, insertDate,  updateDate, address, registerEmployee)
        {
            FullName = fullName;            
            BirthDay = birthDay;
            Sexo = sexo;
            CPF = cPF;
        }

        public override bool Equals(object obj)
        {
            return obj is SupplierPhysical physical &&
                   Id == physical.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
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
