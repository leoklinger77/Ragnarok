using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ragnarok.Repository
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly RagnarokContext _context;

        public BusinessRepository(RagnarokContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            try
            {
                Business business = FindById(id);
                _context.Business.Remove(business);
                _context.SaveChanges();

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICollection<Business> FindAlls()
        {
            try
            {
                return _context.Business.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICollection<BusinessPhysical> FindAllsCpf(string cpf)
        {
            try
            {
                return _context.BusinessPhysicals.Where(x => x.CPF == cpf).AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICollection<BusinessJuridical> FindAllsCpnj(string cnpj)
        {
            try
            {
                return _context.BusinessJuridical.Where(x => x.CNPJ == cnpj).AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICollection<Business> FindAllsEmals(string email)
        {
            try
            {
                return _context.Business.Where(x => x.Email == email).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Business FindById(int id)
        {
            try
            {
                return _context.Business.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Insert(Business business)
        {
            try
            {
                _context.Business.Add(business);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Business business)
        {
            try
            {
                _context.Business.Update(business);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
