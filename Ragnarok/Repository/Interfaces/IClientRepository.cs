using Ragnarok.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ragnarok.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> FindByIdAsync(int id, int businessId);
        int FindTheClientIdByAddress(int addressId);
        Task<int> NumberOfClients(int businessId);
        void Insert(Client client);
        void UpdateMain(Client client);
        void UpdateAddress(Address address);
        Task RemoveAsync(int id, int businessId);
        Task<ICollection<Client>> FIndAllsAsync(int bussinessId);
        ICollection<Client> FindByEmail(string email, int businessId);
        ICollection<ClientPhysical> FindByCpf(string cpf, int businessId);
        ICollection<ClientJuridical> FindByCnpj(string cnpj, int businessId);
        void RemoveContact(int id);
        Task<Client> QuickSaleAsync(int businessId);
    }
}
