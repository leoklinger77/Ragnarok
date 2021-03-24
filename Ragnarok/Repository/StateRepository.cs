using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ragnarok.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly RagnarokContext _context;

        public StateRepository(RagnarokContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            try
            {
                State state = FindById(id);
                _context.State.Remove(state);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICollection<State> FindAlls()
        {
            try
            {
                return _context.State.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public State FindById(int id)
        {
            try
            {
                return _context.State.FirstOrDefault(x=>x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICollection<State> FindByName(string name)
        {
            try
            {
                return _context.State.Where(x => x.Name == name).AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICollection<State> FindBySigle(string sigla)
        {
            try
            {
                return _context.State.Where(x => x.Sigle == sigla).AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Insert(State state)
        {
            try
            {
                _context.State.Add(state);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(State state)
        {
            try
            {
                _context.State.Update(state);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
