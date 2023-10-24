using Infrastructure.ExternalServices.ExternalServicesClass;
using Infrastructure.ExternalServices.IExtenalServices;
using Microsoft.Extensions.Configuration;
using System.Text.Json; // Add this namespace for JSON serialization

namespace Infrastructure.ExternalServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;
        private readonly string _discountApiUrl;

        public DiscountService(IConfiguration configuration)
        {
            _discountApiUrl = configuration["DiscountApi"];
            _httpClient = new HttpClient();
        }

        public async Task<int> GetDiscountPercentageAsync(Guid productId)
        {
            try
            {
                string requestUrl = $"{_discountApiUrl}{productId}";

                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var discountResponse = JsonSerializer.Deserialize<DiscountResponse>(responseContent);

                    if (discountResponse != null)
                    {
                        return discountResponse.Discount;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Discount percentage error: {ex.Message}");
                throw;
            }
        }
    }
}