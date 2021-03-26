using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ragnarok.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly RagnarokContext _context;

        public CityRepository(RagnarokContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            try
            {
                City city = FindById(id);
                _context.City.Remove(city);
                _context.SaveChanges();
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

        public City FindById(int id)
        {
            try
            {
                return _context.City.FirstOrDefault(x => x.Id == id);
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
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
