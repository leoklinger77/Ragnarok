using Microsoft.AspNetCore.Http;

namespace Ragnarok.Services.Session
{
    public class Session
    {
        private readonly IHttpContextAccessor _httpContext;

        public Session(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void Insert(string key, string valor)
        {
            _httpContext.HttpContext.Session.SetString(key, valor);
        }
        public void Update(string key, string valor)
        {
            if (Exist(key))
            {
                Remove(key);
                Insert(key, valor);
            }
        }
        public void Remove(string key)
        {
            _httpContext.HttpContext.Session.Remove(key);
        }
        public string GetConsult(string key)
        {
            if (Exist(key))
            {
                return _httpContext.HttpContext.Session.GetString(key);
            }
            return null;
        }
        public bool Exist(string key)
        {
            if (_httpContext.HttpContext.Session.GetString(key) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void RemoveAll()
        {
            _httpContext.HttpContext.Session.Clear();
        }
    }
}
