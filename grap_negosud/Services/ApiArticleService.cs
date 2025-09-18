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
    public class ApiArticleService
    {
        private readonly HttpClient _httpClient;

        public ApiArticleService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri("https://localhost:7103/api/")
            };
        }
        public async Task<List<Article>> GetArticlesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Article>>("Articles");
        }
        public async Task<Article> GetArticleAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Article>($"Articles/{id}");
        }
        public async Task AddArticleAsync(Article article)
        {
            var response = await _httpClient.PostAsJsonAsync("Articles", article);
            response.EnsureSuccessStatusCode();
        }
        public async Task UpdateArticleAsync(Article article)
        {
            var response = await _httpClient.PutAsJsonAsync($"Articles/{article.Id}", article);
            response.EnsureSuccessStatusCode();
        }
        public async Task DeleteArticleAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Articles/{id}");
        }
    }
}
