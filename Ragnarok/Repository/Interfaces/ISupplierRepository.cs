﻿using Ragnarok.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ragnarok.Repository.Interfaces
{
    public interface ISupplierRepository
    {
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
