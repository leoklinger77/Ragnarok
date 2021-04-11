using Ragnarok.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok.Repository.Interfaces
{
    public interface IDiscountProductStockRepository
    {
        Task InsertAsync(DiscountProductStock discountProductStock);
    }
}
