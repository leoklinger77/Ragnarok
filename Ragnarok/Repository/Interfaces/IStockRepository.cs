﻿using Ragnarok.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ragnarok.Repository.Interfaces
{
    public interface IStockRepository
    {
        Task<ICollection<Stock>> FindAllsAsync(int businessId);
        Task<ICollection<Stock>> FindAllsProductsNotDiscount(int businessId);
        Task<Stock> FindByIdAsync(int id, int businessId);
        Task Insert(Stock stock);
        Task Update(Stock stock);
    }
}
