using Ragnarok.Models;
using System.Collections.Generic;

namespace Ragnarok.Repository.Interfaces
{
    public interface ISupplierRepository
    {
        Supplier FindById(int id);

        void Insert(Supplier supplier);
        void UpdateMain(Supplier supplier);
        void UpdateAddress(Address address);
        void Remove(int id);
        ICollection<Supplier> FIndAlls(int bussinessId);
        ICollection<Supplier> FindByEmail(string email, int businessId);
        ICollection<SupplierPhysical> FindByCpf(string cpf, int businessId);
        ICollection<SupplierJuridical> FindByCnpj(string cnpj, int businessId);
    }
}
