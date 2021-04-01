using Ragnarok.Models.Enums;
using Ragnarok.Services.Lang;
using Ragnarok.Services.Validation.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_Employee")]
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public string Name { get; set; }
        private string _CPF;
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        [Display(Name = "Nascimento")]
        public DateTime BirthDay { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public Sexo Sexo { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public Boolean Active { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        [Display(Name = "E-mail")]
        [EmailValidationEmployee]
        public string Email { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public string Login { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_002")]
        [NotMapped]
        public string ConfirmePassword { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Business Business { get; set; }
        public int BusinessId { get; set; }
        public PositionName PositionName { get; set; }
        public int PositionNameId { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public Employee RegisterEmployee { get; set; }
        public int? RegisterEmployeeId { get; set; }
        public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        [CPFValidationEmployee]
        public string CPF
        {
            get { return _CPF; }
            set
            {
                _CPF = value.Replace(".", "").Replace("-", "");
            }
        }
        public Employee()
        {
        }

        public Employee(int id, string name, string cPF, DateTime birthDay, Sexo sexo, bool active,
            string email, string login, string password, string confirmePasswor, DateTime insertDate,
            DateTime? updateDate, Business business, PositionName positionName, Address address, Employee registerEmployee)
        {
            Id = id;
            Name = name;
            CPF = cPF;
            BirthDay = birthDay;
            Sexo = sexo;
            Active = active;
            Email = email;
            Login = login;
            Password = password;
            ConfirmePassword = confirmePasswor;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            Business = business;
            PositionName = positionName;
            Address = address;
            RegisterEmployee = registerEmployee;
        }

        public override bool Equals(object obj)
        {
            return obj is Employee employee &&
                   Id == employee.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public int Age()
        {
            int age = DateTime.Now.Year - BirthDay.Year;

            if (DateTime.Now.DayOfWeek < BirthDay.DayOfWeek)
            {
                age += 1;
            }
            return age;
        }

        public int HomeTime()
        {
            int age = DateTime.Now.Year - InsertDate.Year;

            if (DateTime.Now.DayOfWeek < InsertDate.DayOfWeek)
            {
                age += 1;
            }
            return age;
        }
    }
}
