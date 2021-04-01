using Ragnarok.Models;
using System.Collections.Generic;

namespace Ragnarok.Repository.Interfaces
{
    public interface IClientRepository
    {
        Client FindById(int id, int businessId);
        int FindTheClientIdByAddress(int addressId);

        void Insert(Client client);
        void UpdateMain(Client client);
        void UpdateAddress(Address address);
        void Remove(int id, int businessId);
        ICollection<Client> FIndAlls(int bussinessId);
        ICollection<Client> FindByEmail(string email, int businessId);
        ICollection<ClientPhysical> FindByCpf(string cpf, int businessId);
        ICollection<ClientJuridical> FindByCnpj(string cnpj, int businessId);
        void RemoveContact(int id);
    }
}
