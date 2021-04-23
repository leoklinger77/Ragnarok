using Ragnarok.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace Ragnarok.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<IPagedList<Client>> FindAllsPagedListAsync(int? page, int? numberPerPage, string search, DateTime startDate, DateTime endDate, int businessId);
        Task<Client> FindByIdAsync(int id, int businessId);
        Task<int> NumberOfClients(int businessId);
        Task RemoveAsync(int id, int businessId);
        Task<Client> QuickSaleAsync(int businessId);
        Task<ICollection<Client>> FIndAllsAsync(int bussinessId);
        ICollection<Client> FindByEmail(string email, int businessId);
        ICollection<ClientPhysical> FindByCpf(string cpf, int businessId);
        ICollection<ClientJuridical> FindByCnpj(string cnpj, int businessId);
        int FindTheClientIdByAddress(int addressId);        
        void Insert(Client client);
        void UpdateMain(Client client);
        void UpdateAddress(Address address);
        void RemoveContact(int id);
        Task<ICollection<Client>> FindAllsAsync(string search, DateTime startDate, DateTime endDate, int businessId);
    }
}
