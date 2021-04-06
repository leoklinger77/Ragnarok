using Ragnarok.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ragnarok.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee Login(string login, string password);
        Employee LoginUpdate(int id);
        Employee Forgot(string login);

        void Insert(Employee employee);        
        void UpdateMain(Employee employee);
        void UpdateAddress(Address address);
        void UpdatePassword(Employee employee);        
        void Remove(int id, int businessId);
        void RemoveContact(int id);
        Task<Employee> FindByIdAsync(int id);
        Address FindByIdAddress(int id);
        Contact FindByIdContacts(int id);
        Task<ICollection<Employee>> FindAllsAsync(int businessId);
        ICollection<Employee> FindByEmail(string email, int businessId);
        ICollection<Employee> FindByCpf(string cpf, int businessId);


    }
}
