using Newtonsoft.Json;
using Ragnarok.Models;

namespace Ragnarok.Services.Login
{
    public class EmployeeLogin
    {
        private readonly Session.Session _session;
        private string Key = ".Employee";

        public EmployeeLogin(Session.Session session)
        {
            _session = session;
        }

        public void SetEmployee(Employee employee)
        {
            _session.Insert(Key, JsonConvert.SerializeObject(employee));
        }

        public Employee GetEmployee()
        {
            if (_session.GetConsult(Key) != null)
            {
                return JsonConvert.DeserializeObject<Employee>(_session.GetConsult(Key));
            }

            return null;

        }
        public void Update(Employee employee)
        {
            _session.Update(Key, JsonConvert.SerializeObject(employee));
        }

        public void Remove()
        {
            _session.Remove(Key);
        }
    }
}
