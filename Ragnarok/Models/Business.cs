using Ragnarok.Services.Validation.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_Business")]
    public abstract class Business
    {
        public int Id { get; set; }
        [EmailValidationBusiness]
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
        public ICollection<Employee> Employee { get; set; } = new HashSet<Employee>();

        public Business()
        {
        }
        protected Business(int id, string email, DateTime insertDate, DateTime? updateDate, Address address)
        {
            Id = id;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            Address = address;
        }
        public abstract int Age();
        public abstract int RegisteredTime();
    }
}
