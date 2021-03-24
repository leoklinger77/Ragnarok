using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_Employee")]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDay { get; set; }
        public Boolean Action { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        [NotMapped]
        public string ConfirmePasswor { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public PositionName PositionName { get; set; }
        public int PositionNameId { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }

        public Employee()
        {
        }

        public Employee(int id, string name, string cPF, DateTime birthDay, bool action, string email, 
            string login, string password, string confirmePasswor, DateTime insertDate, DateTime? updateDate, 
            PositionName positionName, Address address)
        {
            Id = id;
            Name = name;
            CPF = cPF;
            BirthDay = birthDay;
            Action = action;
            Email = email;
            Login = login;
            Password = password;
            ConfirmePasswor = confirmePasswor;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            PositionName = positionName;
            Address = address;
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
