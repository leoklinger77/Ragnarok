using Ragnarok.Models.ViewModels.Graphics;
using Ragnarok.Repository.Interfaces;
using System.Threading.Tasks;

namespace Ragnarok.Services.Graphics
{
    public class GraphicsGenerator
    {
        private readonly ISalesOrderRepository _salesOrderRepository;

        public GraphicsGenerator(ISalesOrderRepository salesOrderRepository)
        {
            _salesOrderRepository = salesOrderRepository;
        }

        public async Task SalesForTheLastSevenDays(int businessId)
        {
            var list = await _salesOrderRepository.FindAllsSevenDadys(businessId);

            GraphicsStandard graphics = new GraphicsStandard();

            
        }
    }
}
