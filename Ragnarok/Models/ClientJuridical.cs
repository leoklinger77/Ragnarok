using Ragnarok.Services.Lang;
using Ragnarok.Services.Validation.Client;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_ClientJuridical")]
    public class ClientJuridical : Client
    {
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        [Display(Name ="Razão Social")]
        public string CompanyName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        [Display(Name = "Nome Fantasia")]
        public string FantasyName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        [Display(Name = "Data de Abertura")]
        public DateTime OpeningDate { get; set; }
        
        private string _cnpj;
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        [CNPJValidationClient]
        public string CNPJ
        {
            get { return _cnpj; }
            set { _cnpj = value.Replace(".", "").Replace("/", "").Replace("-", ""); }
        }

        public ClientJuridical() : base()
        {
        }

        public ClientJuridical(int id, string email, bool active, DateTime insertDate, DateTime? updateDate, Address address, Employee registerEmployee,
            string companyName, string fantasyName, DateTime openingDate, string cNPJ)
             : base(id, email, active, insertDate, updateDate, address, registerEmployee)
        {
            CompanyName = companyName;
            FantasyName = fantasyName;
            OpeningDate = openingDate;
            CNPJ = cNPJ;
        }

        public override bool Equals(object obj)
        {
            return obj is ClientJuridical juridical &&
                   Id == juridical.Id;
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
