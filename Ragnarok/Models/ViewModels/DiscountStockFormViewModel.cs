using System.Collections.Generic;

namespace Ragnarok.Models.ViewModels
{
    public class DiscountStockFormViewModel
    {
        public DiscountStock DiscountStock { get; set; }
        public List<int> ProductsList { get; set; } = new List<int>();
    }
}
