using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.ExternalServicesClass
{
    public class DiscountResponse
    {
        [JsonPropertyName("discount")]
        public int Discount { get; set; }
    }
}
