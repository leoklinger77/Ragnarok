using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ragnarok.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly RagnarokContext _context;

        public AddressRepository(RagnarokContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            try
            {
                Address address = FindById(id);
                _context.Address.Remove(address);
                _context.SaveChanges();
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICollection<Address> FindAlls()
        {
            try
            {
                return _context.Address.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Address FindById(int id)
        {
            try
            {
                return _context.Address.FirstOrDefault(x=>x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Insert(Address address)
        {
            try
            {
                _context.Address.Add(address);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Address address)
        {
            try
            {
                _context.Address.Update(address);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
