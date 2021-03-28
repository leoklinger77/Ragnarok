using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ragnarok.Repository
{
    public class PositionNameRepository : IPositionNameRepository
    {
        private readonly RagnarokContext _context;

        public PositionNameRepository(RagnarokContext context)
        {
            _context = context;
        }

        public ICollection<PositionName> FindAlls(int businessId)
        {
            try
            {
                return _context.PositionName.Where(x => x.BusinessId == businessId)
                    .Include(x=>x.Employee)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public PositionName FindById(int id)
        {
            try
            {
                return _context.PositionName
                    .Include(x=>x.Employee)
                    .FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Insert(PositionName positionName)
        {
            try
            {
                _context.PositionName.Add(positionName);
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
                PositionName positionName = FindById(id);
                _context.PositionName.Remove(positionName);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(PositionName positionName)
        {
            try
            {
                _context.PositionName.Update(positionName);
                _context.Entry(positionName).Property(x => x.InsertDate).IsModified = false;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
