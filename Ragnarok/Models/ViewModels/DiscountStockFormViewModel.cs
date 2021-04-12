using System.Collections.Generic;

namespace Ragnarok.Models.ViewModels
{
    public class DiscountStockFormViewModel
    {
        public DiscountStock DiscountStock { get; set; }
        public ICollection<int> ProductsList { get; set; } = new HashSet<int>();
    }
}
