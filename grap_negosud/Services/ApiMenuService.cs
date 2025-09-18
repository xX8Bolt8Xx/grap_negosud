using grap_negosud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Menu = grap_negosud.Models.Menu;

namespace grap_negosud.Services
{
    internal class ApiMenuService
    {
        private readonly HttpClient _httpClient;
        public ApiMenuService() 
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7103/api/")
            };
        }
        public async Task<List<Menu>> GetMenusAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Menu>>("Menus");
        }
        public async Task<Menu> GetMenuAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Menu>($"Menus/{id}");
        }
        public async Task AddMenuAsync(Menu menu)
        {
            var response = await _httpClient.PostAsJsonAsync("Menus", menu);
            response.EnsureSuccessStatusCode();
        }
        public async Task UpdateMenuAsync(Menu menu)
        {
            var response = await _httpClient.PutAsJsonAsync($"Menus/{menu.Id}", menu);
            response.EnsureSuccessStatusCode();
        }
        public async Task DeleteMenuAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Menus/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
