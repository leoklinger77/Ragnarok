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

        public ICollection<Client> FIndAlls(int bussinessId)
        {
            try
            {
                return _context.Client.Where(x => x.RegisterEmployee.BusinessId == bussinessId).ToList();
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

        public Client FindById(int id)
        {
            try
            {
                return _context.Client.Where(x => x.Id == id)
                    .Include(x=>x.Address)
                    .Include(x => x.Contacts)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
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

        public void Remove(int id)
        {
            try
            {
                Client client = FindById(id);
                _context.Remove(client.Address);
                _context.Remove(client);
                _context.Remove(client.Contacts);

                _context.SaveChanges();
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
                _context.Address.Add(address);
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
                _context.Client.Add(client);
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
