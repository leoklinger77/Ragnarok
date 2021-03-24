using Ragnarok.Models;
using System.Collections.Generic;

namespace Ragnarok.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee Login(string login, string password);
        Employee Forgot(string login);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Remove(int id);
        Employee FindById(int id);
        ICollection<Employee> FindAlls(int businessId);

    }
}
