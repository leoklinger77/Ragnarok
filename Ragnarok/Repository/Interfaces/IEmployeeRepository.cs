using Ragnarok.Models;
using System.Collections.Generic;

namespace Ragnarok.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee Login(string login, string password);
        Employee LoginUpdate(int id);
        Employee Forgot(string login);
        void Insert(Employee employee);
        void InsertPhone(Contact contact);
        void UpdateMain(Employee employee);
        void UpdateAddress(Address address);
        void UpdatePassword(Employee employee);
        void UpdatePhone(List<Contact> contacts);
        void Remove(int id);
        void RemoveContact(int id);
        Employee FindById(int id);
        Address FindByIdAddress(int id);
        Contact FindByIdContacts(int id);
        ICollection<Employee> FindAlls(int businessId);

    }
}
