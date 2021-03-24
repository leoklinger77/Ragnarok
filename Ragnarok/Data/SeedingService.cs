using Ragnarok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok.Data
{
    public class SeedingService
    {
        public void Seed()
        {
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
        }
    }
}
