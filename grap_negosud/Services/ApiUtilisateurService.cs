using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace grap_negosud.Services
{
    internal class ApiUtilisateurService
    {
        private readonly HttpClient _httpClient;
        public ApiUtilisateurService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7103/api/")
            };
        }
        
    }
}
