using Ragnarok.Models.Enums;
using Ragnarok.Services.Lang;
using Ragnarok.Services.Validation.Client;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ragnarok.Models
{
    [Table("TB_ClientPhysical")]
    public class ClientPhysical : Client
    {
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        [Display(Name = "Nome Completo")]
        public string FullName { get; set; }

        private string _cpf;

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public Sexo Sexo { get; set; }                
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        [Display(Name = "Nascimento")]
        public DateTime BirthDay { get; set; }

        
        [CPFValidationClient]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value.Replace(".", "").Replace("-", ""); }
        }

        public ClientPhysical() : base()
        {
        }

        public ClientPhysical(int id, string email, bool active, DateTime insertDate, DateTime? updateDate, Address address, Employee registerEmployee,
            string fullName, Sexo sexo, DateTime birthDay, string cPF)
            : base(id, email, active, insertDate, updateDate, address, registerEmployee)
        {
            FullName = fullName;
            Sexo = sexo;
            BirthDay = birthDay;
            CPF = cPF;
        }

        public override bool Equals(object obj)
        {
            return obj is ClientJuridical physical &&
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
