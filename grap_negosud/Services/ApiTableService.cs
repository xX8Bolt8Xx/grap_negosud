using grap_negosud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Table = grap_negosud.Models.Table;

namespace grap_negosud.Services
{
    public class ApiTableService
    {
        private readonly HttpClient _httpClient;

        public ApiTableService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7103/api/")
            };
        }

        public async Task<List<Table>> GetTablesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Table>>("Tables");
        }

        public async Task<Table> GetTableAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Table>($"Tables/{id}");
        }

        public async Task AddTableAsync(Table table)
        {
            var response = await _httpClient.PostAsJsonAsync("Tables", table);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateTableAsync(Table table)
        {
            var response = await _httpClient.PutAsJsonAsync($"Tables/{table.Id}", table);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteTableAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Tables/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
} 
