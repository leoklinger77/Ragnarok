using Ragnarok.Services.Validation.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_Supplier")]
    public abstract class Supplier
    {
        public int Id { get; set; }
        [EmailValidationSupplier]
        public string Email { get; set; }
        public Boolean Active { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public Employee RegisterEmployee { get; set; }
        public int RegisterEmployeeId { get; set; }
        public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();

        public Supplier()
        {
        }

        public Supplier(int id, string email, bool active, DateTime insertDate, DateTime? updateDate, Address address, Employee registerEmployee)
        {
            Id = id;
            Email = email;
            Active = active;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            Address = address;
            RegisterEmployee = registerEmployee;
        }

        public abstract int Age();
        public abstract int RegisteredTime();

    }
}
