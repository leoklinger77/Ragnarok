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

            if (_context.Business.Any() || _context.Address.Any() || _context.State.Any() || _context.City.Any() || _context.Contact.Any())
            {
                return;
            }
            State state1 = new State
            {
                Name = "São Paulo",
                Sigle = "SP",
                InsertDate = DateTime.Now                
            };

            City c1 = new City
            {
                Name = "Jandira",
                State = state1,
                InsertDate = DateTime.Now
            };

            Address ad1 = new Address
            {
                ZipCode = "06622280",
                Street = "Rua Santo André",
                Number = 130,
                Neighborhood = "Santa Tereza",
                InsertDate = DateTime.Now,
                City = c1                
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

            _context.State.AddRange(state1);
            _context.City.AddRange(c1);
            _context.Address.AddRange(ad1);
            _context.Business.AddRange(business1);
            _context.Contact.AddRange(contact1);
            _context.SaveChanges();
        }
    }
}
