using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Ragnarok.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly RagnarokContext _context;

        public SupplierRepository(RagnarokContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Supplier>> FIndAllsAsync(int bussinessId)
        {
            try
            {
                return await _context.Supplier.Where(x => x.RegisterEmployee.BusinessId == bussinessId).ToListAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<Supplier>> FindAllsAsync(string search, DateTime startDate, DateTime endDate, int businessId)
        {
            try
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return await _context.Supplier
                        .Include(x => x.RegisterEmployee)
                        .Include(x => x.Address.City.State)
                        .Include(x => x.Contacts)
                        .Where(x => x.RegisterEmployee.BusinessId == businessId
                        && (x.InsertDate.Date >= startDate.Date && x.InsertDate.Date <= endDate.Date))
                        .OrderByDescending(x => x.InsertDate)
                        .ToListAsync();
                }
                return await _context.Supplier
                        .Include(x => x.RegisterEmployee)
                        .Include(x => x.Address.City.State)
                        .Include(x => x.Contacts)
                        .Where(x => x.RegisterEmployee.BusinessId == businessId
                        && x.InsertDate.Date >= startDate.Date && x.InsertDate.Date <= endDate.Date)
                        .OrderByDescending(x => x.InsertDate)
                        .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IPagedList<Supplier>> FindAllsPagedListAsync(int? page, int? numberPerPage, string search, DateTime startDate, DateTime endDate, int businessId)
        {
            try
            {
                int Page = page ?? 1;
                int quantity = numberPerPage ?? 10;
                if (!string.IsNullOrEmpty(search))
                {
                    return await _context.Supplier.AsQueryable()
                        .Include(x => x.RegisterEmployee)
                        .Include(x => x.Address)
                        .Include(x => x.Contacts)
                        .Where(x => x.RegisterEmployee.BusinessId == businessId
                        && (x.InsertDate.Date >= startDate.Date && x.InsertDate.Date <= endDate.Date))
                        .OrderByDescending(x => x.InsertDate)
                        .ToPagedListAsync<Supplier>((int)Page, quantity);
                }
                return await _context.Supplier.AsQueryable()
                        .Include(x => x.RegisterEmployee)
                        .Include(x => x.Address)
                        .Include(x => x.Contacts)
                        .Where(x => x.RegisterEmployee.BusinessId == businessId
                        && x.InsertDate.Date >= startDate.Date && x.InsertDate.Date <= endDate.Date)
                        .OrderByDescending(x => x.InsertDate)
                        .ToPagedListAsync<Supplier>(Page, quantity);
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
                    .Include(x => x.Address.City)
                    .Include(x => x.Address.City.State)
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

