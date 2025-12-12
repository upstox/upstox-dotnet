using System.Text.Json.Serialization;

namespace UpstoxClient.Feeder.Model
{
    public class PositionUpdate
    {
        [JsonPropertyName("instrument_token")]
        public string? InstrumentToken { get; set; }

        [JsonPropertyName("instrument_key")]
        public string? InstrumentKey { get; set; }

        [JsonPropertyName("average_price")]
        public double? AveragePrice { get; set; }

        [JsonPropertyName("buy_value")]
        public double? BuyValue { get; set; }

        [JsonPropertyName("overnight_quantity")]
        public int? OvernightQuantity { get; set; }

        [JsonPropertyName("exchange")]
        public string? Exchange { get; set; }

        [JsonPropertyName("day_buy_value")]
        public double? DayBuyValue { get; set; }

        [JsonPropertyName("day_buy_price")]
        public double? DayBuyPrice { get; set; }

        [JsonPropertyName("overnight_buy_amount")]
        public double? OvernightBuyAmount { get; set; }

        [JsonPropertyName("overnight_buy_quantity")]
        public int? OvernightBuyQuantity { get; set; }

        [JsonPropertyName("day_buy_quantity")]
        public int? DayBuyQuantity { get; set; }

        [JsonPropertyName("day_sell_value")]
        public double? DaySellValue { get; set; }

        [JsonPropertyName("day_sell_price")]
        public double? DaySellPrice { get; set; }

        [JsonPropertyName("overnight_sell_amount")]
        public double? OvernightSellAmount { get; set; }

        [JsonPropertyName("overnight_sell_quantity")]
        public int? OvernightSellQuantity { get; set; }

        [JsonPropertyName("day_sell_quantity")]
        public int? DaySellQuantity { get; set; }

        [JsonPropertyName("multiplier")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double? Multiplier { get; set; }

        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("product")]
        public string? Product { get; set; }

        [JsonPropertyName("sell_value")]
        public double? SellValue { get; set; }

        [JsonPropertyName("buy_price")]
        public double? BuyPrice { get; set; }

        [JsonPropertyName("sell_price")]
        public double? SellPrice { get; set; }

        public override string ToString()
        {
            return $"InstrumentToken={InstrumentToken}, InstrumentKey={InstrumentKey}, AveragePrice={AveragePrice}, BuyValue={BuyValue}, OvernightQuantity={OvernightQuantity}, Exchange={Exchange}, DayBuyValue={DayBuyValue}, DayBuyPrice={DayBuyPrice}, OvernightBuyAmount={OvernightBuyAmount}, OvernightBuyQuantity={OvernightBuyQuantity}, DayBuyQuantity={DayBuyQuantity}, DaySellValue={DaySellValue}, DaySellPrice={DaySellPrice}, OvernightSellAmount={OvernightSellAmount}, OvernightSellQuantity={OvernightSellQuantity}, DaySellQuantity={DaySellQuantity}, Multiplier={Multiplier}, Quantity={Quantity}, Product={Product}, SellValue={SellValue}, BuyPrice={BuyPrice}, SellPrice={SellPrice}";
        }
    }
}
