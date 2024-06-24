using AutoGlass.Model;

namespace AutoGlassWeb.Services
{
    public class WebApiService
    {
        private readonly HttpClient _httpClient;
        public WebApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("WebApiClient");
        }
        public async Task<List<Produto>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("/api/produto");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Produto>>();
        }

        public async Task<HttpResponseMessage> PostProductAsync(Produto produto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/produto", produto);
            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
