using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ragnarok.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RagnarokContext _context;

        public EmployeeRepository(RagnarokContext context)
        {
            _context = context;
        }

        public ICollection<Employee> FindAlls(int businessId)
        {
            try
            {
                return _context.Employee.Where(x => x.BusinessId == businessId)
                    .Include(x => x.PositionName)
                    .ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Employee FindById(int id)
        {
            try
            {
                return _context.Employee
                    .Include(x => x.Contacts)
                    .Include(x => x.Address)
                    .Include(x => x.Address.City)
                    .Include(x => x.Address.City.State)
                    .FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Address FindByIdAddress(int id)
        {
            try
            {
                return _context.Address
                    .Include(x => x.City)
                    .Include(x => x.City.State)
                    .FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Contact FindByIdContacts(int id)
        {
            try
            {
                return _context.Contact.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Employee Forgot(string login)
        {
            try
            {
                return _context.Employee.Where(x => x.Login == login).AsNoTracking().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Insert(Employee employee)
        {
            try
            {
                _context.Employee.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void InsertPhone(Contact contact)
        {
            try
            {
                _context.Contact.Add(contact);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Employee Login(string login, string password)
        {
            try
            {
                return _context.Employee.Where(x => x.Login == login && x.Password == password).AsNoTracking().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Employee LoginUpdate(int id)
        {
            try
            {
                return _context.Employee.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Remove(int id)
        {
            try
            {
                Employee employee = FindById(id);
                _context.Employee.Remove(employee);
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
                Contact contact = FindByIdContacts(id);
                _context.Contact.Remove(contact);
                _context.SaveChanges();
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

        public void UpdateMain(Employee employee)
        {
            try
            {
                _context.Employee.Update(employee);
                //_context.Entry(employee).Property(x => x.AddressId).IsModified = false;
                _context.Entry(employee).Property(x => x.Password).IsModified = false;
                _context.Entry(employee).Property(x => x.Action).IsModified = false;
                _context.Entry(employee).Property(x => x.InsertDate).IsModified = false;
                _context.Entry(employee).Property(x => x.CPF).IsModified = false;

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdatePassword(Employee employee)
        {
            try
            {
                _context.Employee.Update(employee);

                _context.Entry(employee).Property(x => x.Action).IsModified = false;
                _context.Entry(employee).Property(x => x.InsertDate).IsModified = false;
                _context.Entry(employee).Property(x => x.CPF).IsModified = false;
                _context.Entry(employee).Property(x => x.Name).IsModified = false;
                _context.Entry(employee).Property(x => x.BirthDay).IsModified = false;
                _context.Entry(employee).Property(x => x.Email).IsModified = false;
                _context.Entry(employee).Property(x => x.Sexo).IsModified = false;
                _context.Entry(employee).Property(x => x.Login).IsModified = false;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdatePhone(List<Contact> contacts)
        {
            try
            {
                _context.Contact.UpdateRange(contacts);
                foreach (var item in contacts)
                {
                    _context.Entry(item).Property(x => x.InsertDate).IsModified = false;
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
