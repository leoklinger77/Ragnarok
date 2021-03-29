using Ragnarok.Models;
using System.Collections.Generic;

namespace Ragnarok.Repository.Interfaces
{
    public interface IClientRepository
    {
        Client FindById(int id);

        void Insert(Client client);
        void UpdateMain(Client client);
        void UpdateAddress(Address address);
        void Remove(int id);
        ICollection<Client> FIndAlls(int bussinessId);
        ICollection<Client> FindByEmail(string email, int businessId);
        ICollection<ClientPhysical> FindByCpf(string cpf, int businessId);
        ICollection<ClientJuridical> FindByCnpj(string cnpj, int businessId);
    }
}
