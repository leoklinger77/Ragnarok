using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("BusinessPhysical")]
    public class BusinessPhysical : Business
    {
        public string FullName { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDay { get; set; }

        public BusinessPhysical() : base()
        {
        }

        public BusinessPhysical(int id, DateTime insertDate, DateTime updateDate, Address address, string fullName, string cPF, DateTime birthDay) 
            : base(id, insertDate, updateDate, address)
        {
            FullName = fullName;
            CPF = cPF;
            BirthDay = birthDay;
        }

        public override bool Equals(object obj)
        {
            return obj is BusinessPhysical physical &&
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
            int time = DateTime.Now.Year - InsertDate.Year;

            if (DateTime.Now.DayOfWeek < InsertDate.DayOfWeek)
            {
                time += 1;
            }
            return time;
        }
    }
}
