using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiDemo.Data
{
    public class UserService
    {
        private readonly IHttpClientFactory _httpFactory;

        public UserService(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        public async Task<List<User>> GetUsers(string url)
        {
            using (HttpClient httpclient = _httpFactory.CreateClient())
            using (HttpResponseMessage response = await httpclient.GetAsync(url))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    List<User> users = await response.Content.ReadAsAsync<List<User>>();
                    return users;
                }
                return null;
                
            }
        }
    }
}
