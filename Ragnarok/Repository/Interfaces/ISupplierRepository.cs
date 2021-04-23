using Ragnarok.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace Ragnarok.Repository.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IPagedList<Supplier>> FindAllsPagedListAsync(int? page, int? numberPerPage, string search, DateTime startDate, DateTime endDate, int businessId);
        Task<List<Supplier>> FindAllsAsync(string search, DateTime startDate, DateTime endDate, int businessId);
        Supplier FindById(int id, int bussinessId);
        void Insert(Supplier supplier);
        void UpdateMain(Supplier supplier);
        void UpdateAddress(Address address);
        void Remove(int id, int bussinessId);
        Task<ICollection<Supplier>> FIndAllsAsync(int bussinessId);
        ICollection<Supplier> FindByEmail(string email, int businessId);
        ICollection<SupplierPhysical> FindByCpf(string cpf, int businessId);
        ICollection<SupplierJuridical> FindByCnpj(string cnpj, int businessId);
        int FindTheClientIdByAddress(int addressId);
        void RemoveContact(int id);

    }
}
