using Newtonsoft.Json;
using Ragnarok.Models;

namespace Ragnarok.Services.Login
{
    public class OpenBox
    {
        private readonly Session.Session _session;
        private string key = ".Box";

        public OpenBox(Session.Session session)
        {
            _session = session;
        }

        public void SetBox(SaleBox saleBox)
        {
            _session.Insert(key, JsonConvert.SerializeObject(saleBox));
        }
        public SaleBox GetSaleBox()
        {
            if (_session.GetConsult(key) != null)
            {
                return JsonConvert.DeserializeObject<SaleBox>(_session.GetConsult(key));
            }
            return null;
        }
        public void Update(SaleBox saleBox)
        {
            _session.Update(key, JsonConvert.SerializeObject(saleBox));
        }
        public void Remove()
        {
            _session.Remove(key);
        }

    }
}
