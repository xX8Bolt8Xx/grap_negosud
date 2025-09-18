using grap_negosud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace grap_negosud.Services
{
    internal class ApiCommandeService
    {
        private readonly HttpClient _httpClient;
        public ApiCommandeService() 
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7103/api/")
            };
        }
        public async Task<List<Commande>> GetCommandesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Commande>>("Commandes");
        }
        public async Task<Commande> GetCommandeAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Commande>($"Commandes/{id}");
        }
        public async Task AddCommandeAsync(Commande commande)
        {
            var response = await _httpClient.PostAsJsonAsync("Commandes", commande);
            response.EnsureSuccessStatusCode();
        }
        public async Task UpdateCommandeAsync(Commande commande)
        {
            var response = await _httpClient.PutAsJsonAsync($"Commandes/{commande.Id}", commande);
            response.EnsureSuccessStatusCode();
        }
        public async Task DeleteCommandeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Commandes/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
