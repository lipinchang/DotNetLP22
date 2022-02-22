using ConsumeAPIEFApplication.Models;
using Newtonsoft.Json;

namespace ConsumeAPIEFApplication.Services
{
    public class ProductRepo : IRepo<int, Product>
    {
        private readonly HttpClient _httpClient;

        public ProductRepo()
        {
            _httpClient = new HttpClient();
        }
        public async Task<Product> Add(Product item)
        {
            using (_httpClient)
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PostAsJsonAsync("http://localhost:5032/api/Product", item))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var products = JsonConvert.DeserializeObject<Product>(responseText);
                        return products;
                    }
                }
            }
            return null;
        }

        public async Task<Product> Delete(int key)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.DeleteAsync("http://localhost:5032/api/Product?id=" + key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<Product>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }

        public async Task<Product> Get(int key)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:5032/api/Product/GetProduct?id=" + key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<Product>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:5032/api/Product/GetAllProducts"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var products = JsonConvert.DeserializeObject<List<Product>>(responseText);
                        return products.ToList();
                    }
                }
            }
            return null;
        }

        public async Task<Product> Update(Product item)
        {
            using (_httpClient)
            {
                // StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PutAsJsonAsync<Product>("http://localhost:5032/api/Product?id=" + item.Id, item))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<Product>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }
    }
}
