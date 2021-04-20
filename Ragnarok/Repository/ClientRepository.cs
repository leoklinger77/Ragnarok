using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly RagnarokContext _context;

        public ClientRepository(RagnarokContext ragnarokContext)
        {
            _context = ragnarokContext;
        }

        public async Task<ICollection<Client>> FIndAllsAsync(int bussinessId)
        {
            try
            {
                return await _context.Client.Where(x => x.RegisterEmployee.BusinessId == bussinessId).ToListAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public ICollection<ClientJuridical> FindByCnpj(string cnpj, int businessId)
        {
            try
            {
                return _context.ClientJuridical.Where(x => x.RegisterEmployee.BusinessId == businessId && x.CNPJ == cnpj).AsNoTracking().ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public ICollection<ClientPhysical> FindByCpf(string cpf, int businessId)
        {
            try
            {
                return _context.ClientPhysical.Where(x => x.RegisterEmployee.BusinessId == businessId && x.CPF == cpf).AsNoTracking().ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public ICollection<Client> FindByEmail(string email, int businessId)
        {
            try
            {
                return _context.Client.Where(x => x.RegisterEmployee.BusinessId == businessId && x.Email == email).AsNoTracking().ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Client> FindByIdAsync(int id, int businessId)
        {
            try
            {
                return await _context.Client.Where(x => x.Id == id && x.RegisterEmployee.BusinessId == businessId)
                    .Include(x => x.Address)
                    .Include(x => x.Address.City)
                    .Include(x => x.Address.City.State)
                    .Include(x => x.Contacts)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public int FindTheClientIdByAddress(int addressId)
        {
            return _context.Client.Where(x => x.AddressId == addressId)
                    .AsNoTracking()
                    .First().Id;
        }

        public void Insert(Client client)
        {
            try
            {
                _context.Client.Add(client);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<int> NumberOfClients(int businessId)
        {
            try
            {
                return  await _context.Client.Select(x => x.RegisterEmployee.BusinessId == businessId).CountAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Client> QuickSaleAsync(int businessId)
        {
            try
            {
                Client client = await _context.ClientPhysical.Where(x => x.FullName.Contains("Venda Rápida") && x.RegisterEmployee.BusinessId == businessId)
                    .Include(x => x.Contacts)
                    .Include(x => x.Address.City.State)                    
                    .FirstOrDefaultAsync();
                if (client == null)
                {
                    client = await _context.ClientJuridical.Where(x => x.CompanyName.Contains("Venda Rápida") && x.RegisterEmployee.BusinessId == businessId)
                        .Include(x => x.Contacts)
                        .Include(x => x.Address.City.State)
                        .FirstOrDefaultAsync();
                }
                return client;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemoveAsync(int id, int businessId)
        {
            try
            {
                Client client = await FindByIdAsync(id, businessId);
                _context.Remove(client.Address);
                _context.Remove(client);
                _context.RemoveRange(client.Contacts);

                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void RemoveContact(int id)
        {
            try
            {
                Contact contact = _context.Contact.Where(x => x.Id == id).First();
                if (contact != null)
                {
                    _context.Remove(contact);
                    _context.SaveChanges();
                    return;
                }
                throw new Exception("Id not found");

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void UpdateAddress(Address address)
        {
            try
            {
                _context.Address.Update(address);
                _context.Entry(address).Property(x => x.InsertDate).IsModified = false;
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void UpdateMain(Client client)
        {
            try
            {
                _context.Client.Update(client);
                _context.Entry(client).Property(x => x.InsertDate).IsModified = false;
                if (client is ClientJuridical)
                {
                    _context.Entry((ClientJuridical)client).Property(x => x.CNPJ).IsModified = false;
                    _context.Entry((ClientJuridical)client).Property(x => x.OpeningDate).IsModified = false;
                }
                else
                {
                    _context.Entry((ClientPhysical)client).Property(x => x.CPF).IsModified = false;
                    _context.Entry((ClientPhysical)client).Property(x => x.BirthDay).IsModified = false;
                }

                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

    }
}
