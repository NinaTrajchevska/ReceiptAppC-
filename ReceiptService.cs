using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptApp
{
    public class ReceiptService
    {
        private const string apiUrl = "https://interview-task-api.mca.dev/qr-scanner-codes/alpha-qr-gFpwhsQ8fkY1";
        private readonly HttpClient httpClient;

        public ReceiptService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Product>> GetReceiptData()
        {
            try
            {
                var response = await httpClient.GetFromJsonAsync<List<Product>>(apiUrl);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return null;
            }
        }
    }
}

