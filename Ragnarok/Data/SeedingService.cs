using Ragnarok.Models;
using System;
using System.Linq;

namespace Ragnarok.Data
{
    public class SeedingService
    {
        private readonly RagnarokContext _context;

        public SeedingService(RagnarokContext ragnarokContext)
        {
            _context = ragnarokContext;
        }

        public void Seed()
        {

            if (_context.Business.Any() || _context.Address.Any() || _context.Contact.Any())
            {
                return;
            }
            Address ad1 = new Address
            {
                ZipCode = "06622280",
                Street = "Rua Santo André",
                Number = 130,
                Neighborhood = "Santa Tereza",
                InsertDate = DateTime.Now,
                CityId = 887                
            };

            Business business1 = new BusinessPhysical
            {
                FullName = "Primeiro Comercio Pessoa Fisica",
                Email = "leandro@gmail.com",
                CPF = "36018556820",
                BirthDay = DateTime.Parse("11/09/1995"),
                InsertDate = DateTime.Now,
                Address = ad1                
            };

            Contact contact1 = new Contact
            {
                TypeNumber = Models.Enums.TypeNumber.Celular,
                DDD = "11",
                Number = "954665152",
                Business = business1,
                InsertDate = DateTime.Now
            };

            Address ad2 = new Address
            {
                ZipCode = "06449162",
                Street = "Rua Goiabeira",
                Number = 71,
                Neighborhood = "Viana",
                InsertDate = DateTime.Now,
                CityId = 263
            };

            PositionName positionName = new PositionName
            {
                Name = "Desenvolvedor",
                InsertDate = DateTime.Now,
                Business = business1
            };

            Employee employee = new Employee
            {
                Name = "Klinger Oliveira",
                CPF = "36018556820",
                Email = "klinger@gmail.com",
                Login = "klinger@gmail.com",
                Sexo = Models.Enums.Sexo.Masculino,
                Password = "123",
                Address = ad2,
                InsertDate = DateTime.Now,
                Active = true,
                BirthDay = DateTime.Parse("11/09/1995"),
                PositionName = positionName,
                Business = business1,
                RegisterEmployee = null
                
            };

            Contact contact2 = new Contact
            {
                TypeNumber = Models.Enums.TypeNumber.Celular,
                DDD = "11",
                Number = "945624568",
                InsertDate = DateTime.Now,
                Employee = employee
            };

            _context.Address.AddRange(ad1, ad2);
            _context.PositionName.AddRange(positionName);
            _context.Business.AddRange(business1);
            _context.Employee.AddRange(employee);            
            _context.Contact.AddRange(contact1, contact2);
            _context.SaveChanges();
        }
    }
}
