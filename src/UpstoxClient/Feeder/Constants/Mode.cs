using System.Text.Json.Serialization;

namespace UpstoxClient.Feeder.Constants
{
    /// <summary>
    /// Subscription modes for market data feeds.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Mode
    {
        LTPC,
        FULL,
        OPTION_GREEKS,
        FULL_D30
    }
}
