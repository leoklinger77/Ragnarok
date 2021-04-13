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
    public class CityRepository : ICityRepository
    {
        private readonly RagnarokContext _context;

        public CityRepository(RagnarokContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                City city = await FindByIdAsync(id);
                _context.City.Remove(city);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICollection<City> FindAlls()
        {
            try
            {
                return _context.City.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<City> FindByIdAsync(int id)
        {
            try
            {
                return await _context.City.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICollection<City> FindByName(string name)
        {
            try
            {
                return _context.City.Where(x => x.Name == name).AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public City FindByNameAndState(string name, string stateSigle)
        {
            try
            {
                return _context.City.Where(x => x.Name == name && x.State.Sigle == stateSigle)
                    .Include(x=>x.State)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Insert(City city)
        {
            try
            {
                _context.City.Add(city);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(City city)
        {
            try
            {
                _context.City.Update(city);
                _context.Entry(city).Property(x => x.InsertDate).IsModified = false;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
