using Microsoft.AspNetCore.Mvc;
using System;

namespace Ragnarok.Models
{
    [Area("TB_BusinessJuridical")]
    public class BusinessJuridical : Business
    {
        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public string CNPJ { get; set; }
        public DateTime OpeningDate { get; set; }

        public BusinessJuridical()
        {
        }

        public BusinessJuridical(int id, DateTime insertDate, DateTime updateDate, Address address, string companyName, string fantasyName, string cNPJ, DateTime openingDate)
            : base(id, insertDate, updateDate, address)
        {
            CompanyName = companyName;
            FantasyName = fantasyName;
            CNPJ = cNPJ;
            OpeningDate = openingDate;
        }
        public override bool Equals(object obj)
        {
            return obj is BusinessJuridical juridical &&
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
            int time = DateTime.Now.Year - InsertDate.Year;
            if (DateTime.Now.DayOfWeek < InsertDate.DayOfWeek)
            {
                time += 1;
            }
            return time;
        }
    }
}
