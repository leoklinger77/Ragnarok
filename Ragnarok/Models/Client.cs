using Ragnarok.Services.Validation.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_Client")]
    public abstract class Client
    {
        public int Id { get; set; }
        [EmailValidationClient]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public Boolean Active { get; set; }
        [Display(Name = "Cadastro")]
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public Employee RegisterEmployee { get; set; }
        public int RegisterEmployeeId { get; set; }
        public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();

        protected Client()
        {
        }

        protected Client(int id, string email, bool active, DateTime insertDate, DateTime? updateDate, Address address, Employee registerEmployee)
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
