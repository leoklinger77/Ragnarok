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
                return _context.Employee.Where(x => x.BusinessId == businessId).ToList();

            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Employee FindById(int id)
        {
            try
            {
                return _context.Employee.FirstOrDefault(x => x.Id == id);
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

        public void Update(Employee employee)
        {
            try
            {
                _context.Employee.Update(employee);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
