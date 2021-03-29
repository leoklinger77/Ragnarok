using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ServiceModel.Channels;

namespace Ragnarok.Models
{
    [Table("TB_ClientPhysical")]
    public class ClientPhysical : Client
    {
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = ("MSG_E_002"))]
        public string FullName { get; set; }

        private string _cpf;
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = ("MSG_E_002"))]
        public DateTime BirthDay { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = ("MSG_E_002"))]
        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value.Replace(".", "").Replace("-", ""); }
        }

        public ClientPhysical()
        {
        }

        public ClientPhysical(string fullName, DateTime birthDay, string cPF,
            int id, string email, DateTime insertDate, DateTime? updateDate, Address address, Employee registerEmployee)
            : base(id, email, insertDate, updateDate, address, registerEmployee)
        {
            FullName = fullName;
            BirthDay = birthDay;
            CPF = cPF;
        }

        public override bool Equals(object obj)
        {
            return obj is ClientPhysical physical &&
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
