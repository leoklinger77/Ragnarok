using Ragnarok.Models.Enums;
using Ragnarok.Services.Validation.Contact;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_Contact")]
    public class Contact
    {
        public int Id { get; set; }
        public TypeNumber TypeNumber { get; set; }
        private string _ddd;        
        private string _number;
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Business Business { get; set; }
        public int? BusinessId { get; set; }
        public Employee Employee { get; set; }
        public int? EmployeeId { get; set; }

        public string DDD
        {
            get{ return _ddd; }
            set { _ddd = value.Replace("(", "").Replace(")", ""); }
        }
        [NumberValidation]
        public string Number
        {
            get { return _number; }
            set { _number = value.Replace(".", "").Replace("-", ""); }
        }
        public Contact()
        {
        }

        public Contact(int id, TypeNumber typeNumber, string dDD, string number, DateTime insertDate, DateTime? updateDate, Business business, Employee employee)
        {
            Id = id;
            TypeNumber = typeNumber;
            DDD = dDD;
            Number = number;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            Business = business;
            Employee = employee;
        }

        public override bool Equals(object obj)
        {
            return obj is Contact contact &&
                   Id == contact.Id &&
                   TypeNumber == contact.TypeNumber &&
                   DDD == contact.DDD &&
                   Number == contact.Number;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, TypeNumber, DDD, Number);
        }
    }
}
