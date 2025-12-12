using System.Text.Json.Serialization;

namespace UpstoxClient.Feeder.Model
{
    public class HoldingUpdate
    {
        [JsonPropertyName("instrument_token")]
        public string? InstrumentToken { get; set; }

        [JsonPropertyName("instrument_key")]
        public string? InstrumentKey { get; set; }

        [JsonPropertyName("average_price")]
        public double? AveragePrice { get; set; }

        [JsonPropertyName("isin")]
        public string? Isin { get; set; }

        [JsonPropertyName("cnc_used_quantity")]
        public int? CncUsedQuantity { get; set; }

        [JsonPropertyName("collateral_quantity")]
        public int? CollateralQuantity { get; set; }

        [JsonPropertyName("collateral_type")]
        public string? CollateralType { get; set; }

        [JsonPropertyName("collateral_update_quantity")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double? CollateralUpdateQuantity { get; set; }

        [JsonPropertyName("company_name")]
        public string? CompanyName { get; set; }

        [JsonPropertyName("haircut")]
        public double? Haircut { get; set; }

        [JsonPropertyName("product")]
        public string? Product { get; set; }

        [JsonPropertyName("quantity")]
        public double? Quantity { get; set; }

        [JsonPropertyName("t1_quantity")]
        public int? T1Quantity { get; set; }

        [JsonPropertyName("exchange")]
        public string? Exchange { get; set; }

        public override string ToString()
        {
            return $"InstrumentToken={InstrumentToken}, InstrumentKey={InstrumentKey}, AveragePrice={AveragePrice}, Isin={Isin}, CncUsedQuantity={CncUsedQuantity}, CollateralQuantity={CollateralQuantity}, CollateralType={CollateralType}, CollateralUpdateQuantity={CollateralUpdateQuantity}, CompanyName={CompanyName}, Haircut={Haircut}, Product={Product}, Quantity={Quantity}, T1Quantity={T1Quantity}, Exchange={Exchange}";
        }
    }
}
