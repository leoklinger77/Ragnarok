using System.Collections.Generic;

namespace Ragnarok.Models.ViewModels
{
    public class HomePageFormViewModel
    {
        public ICollection<SalesOrder> SalesOrder { get; set; }
        public int NumberOfClients { get; set; }
    }
}
