using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_Supplier")]
    public abstract class Supplier
    {
        public int id { get; set; }
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

        protected Supplier(int id, DateTime insertDate, DateTime? updateDate, Address address, Employee registerEmployee)
        {
            this.id = id;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            Address = address;
            RegisterEmployee = registerEmployee;
        }

        public abstract int Age();
        public abstract int RegisteredTime();

    }
}
