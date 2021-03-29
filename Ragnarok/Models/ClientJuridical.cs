using Ragnarok.Services.Lang;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_ClientJuridical")]
    public class ClientJuridical : Client
    {
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = ("MSG_E_002"))]
        public string CompanyName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = ("MSG_E_002"))]
        public string FantasyName { get; set; }

        private string _CNPJ;
        public DateTime OpeningDate { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = ("MSG_E_002"))]
        public string CNPJ
        {
            get { return _CNPJ; }
            set { _CNPJ = value.Replace(".", "").Replace("\\", "").Replace("-", ""); }
        }

        public ClientJuridical() : base()
        {
        }

        public ClientJuridical(string companyName, string fantasyName, DateTime openingDate, string cNPJ,
            int id, string email, DateTime insertDate, DateTime? updateDate, Address address, Employee registerEmployee)
            : base(id, email, insertDate, updateDate, address, registerEmployee)
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
