using CustomerServiceApplication.Models;
using Newtonsoft.Json;
using System.Text;

namespace CustomerServiceApplication.Services
{
    public class CustomerRepo : IRepo<int, Customer>    //call web api here as there is no context here
    {
        private readonly HttpClient _httpClient;

        public CustomerRepo()
        {
            _httpClient = new HttpClient();
            //_httpClient.BaseAddress = "http://localhost:5054/api/Customer";    //base address of api
        }

        public async Task<Customer> Add(Customer item)
        {
            
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PostAsync("http://localhost:5054/api/Customer", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var customer = JsonConvert.DeserializeObject<Customer>(responseText);
                        return customer;
                    }
                }
                
            }
            return null;
        }

        public async Task<Customer> Delete(int key)
        {
            using (_httpClient)
            {

                using (var response = await _httpClient.DeleteAsync("http://localhost:5054/api/Customer?id="+key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var customer = JsonConvert.DeserializeObject<Customer>(responseText);
                        return customer;
                    }
                }

            }
            return null;
        }

        public async Task<Customer> Get(int key)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:5054/api/Customer/SingleCustomer?id="+key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var customer = JsonConvert.DeserializeObject<Customer>(responseText);
                        return customer;
                    }
                }

            }
            return null;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            using (_httpClient)
            {
                
                using (var response = await _httpClient.GetAsync("http://localhost:5054/api/Customer"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var customers = JsonConvert.DeserializeObject<List<Customer>>(responseText);
                        return customers.ToList();
                    }
                }
                
            }
            return null;
        }

        public async Task<Customer> Update(Customer item)
        {
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PutAsync("http://localhost:5054/api/Customer?id="+item.Id,content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var customer = JsonConvert.DeserializeObject<Customer>(responseText);
                        return customer;
                    }
                }

            }
            return null;
        }
    }
}
