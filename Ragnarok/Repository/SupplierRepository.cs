using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ragnarok.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly RagnarokContext _context;

        public SupplierRepository(RagnarokContext context)
        {
            _context = context;
        }

        public ICollection<Supplier> FIndAlls(int bussinessId)
        {
            try
            {
                return _context.Supplier.Where(x => x.RegisterEmployee.BusinessId == bussinessId).ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public ICollection<SupplierJuridical> FindByCnpj(string cnpj, int businessId)
        {
            try
            {
                return _context.SupplierJuridical.Where(x => x.RegisterEmployee.BusinessId == businessId && x.CNPJ == cnpj).AsNoTracking().ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public ICollection<SupplierPhysical> FindByCpf(string cpf, int businessId)
        {
            try
            {
                return _context.SupplierPhysical.Where(x => x.RegisterEmployee.BusinessId == businessId && x.CPF == cpf).AsNoTracking().ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public ICollection<Supplier> FindByEmail(string email, int businessId)
        {
            try
            {
                return _context.Supplier.Where(x => x.RegisterEmployee.BusinessId == businessId && x.Email == email).AsNoTracking().ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Supplier FindById(int id, int bussinessId)
        {
            try
            {
                return _context.Supplier.Where(x => x.Id == id && x.RegisterEmployee.BusinessId == bussinessId)
                    .Include(x => x.Address)
                    .Include(x => x.Contacts)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public int FindTheClientIdByAddress(int addressId)
        {
            return _context.Supplier.Where(x => x.AddressId == addressId)
                    .AsNoTracking()
                    .First().Id;
        }

        public void Insert(Supplier supplier)
        {
            try
            {
                _context.Supplier.Add(supplier);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Remove(int id, int bussinessId)
        {
            try
            {
                Supplier supplier = FindById(id, bussinessId);
                _context.Remove(supplier.Address);
                _context.Remove(supplier);
                _context.RemoveRange(supplier.Contacts);

                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }      

        public void RemoveContact(int id)
        {
            try
            {
                Contact contact = _context.Contact.Where(x => x.Id == id).First();
                if (contact != null)
                {
                    _context.Remove(contact);
                    _context.SaveChanges();
                    return;
                }
                throw new Exception("Id not found");

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void UpdateAddress(Address address)
        {
            try
            {
                _context.Address.Update(address);
                _context.Entry(address).Property(x => x.InsertDate).IsModified = false;
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void UpdateMain(Supplier supplier)
        {
            try
            {
                _context.Supplier.Update(supplier);
                _context.Entry(supplier).Property(x => x.InsertDate).IsModified = false;
                if (supplier is SupplierJuridical)
                {
                    _context.Entry((SupplierJuridical)supplier).Property(x => x.CNPJ).IsModified = false;
                    _context.Entry((SupplierJuridical)supplier).Property(x => x.OpeningDate).IsModified = false;
                }
                else
                {
                    _context.Entry((SupplierPhysical)supplier).Property(x => x.CPF).IsModified = false;
                    _context.Entry((SupplierPhysical)supplier).Property(x => x.BirthDay).IsModified = false;
                }

                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
