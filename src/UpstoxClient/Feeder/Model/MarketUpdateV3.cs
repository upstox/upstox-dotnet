using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text;

namespace UpstoxClient.Feeder.Model
{
    public class MarketUpdateV3
    {
        [JsonPropertyName("type")]
        public Type? UpdateType { get; set; }

        [JsonPropertyName("feeds")]
        public Dictionary<string, Feed>? Feeds { get; set; }

        [JsonPropertyName("currentTs")]
        public long CurrentTs { get; set; }

        [JsonPropertyName("marketInfo")]
        public MarketInfo? Info { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("MarketUpdateV3 {");

            // Basic properties
            sb.AppendLine($"  UpdateType: {UpdateType}");
            sb.AppendLine($"  CurrentTs: {CurrentTs}");

            // Feeds dictionary
            if (Feeds != null && Feeds.Count > 0)
            {
                sb.AppendLine("  Feeds: {");
                foreach (var feed in Feeds)
                {
                    sb.AppendLine($"    \"{feed.Key}\": {feed.Value?.ToString() ?? "null"}");
                }
                sb.AppendLine("  }");
            }
            else
            {
                sb.AppendLine("  Feeds: null");
            }

            // MarketInfo
            if (Info != null)
            {
                sb.AppendLine($"  Info: {Info.ToString()}");
            }
            else
            {
                sb.AppendLine("  Info: null");
            }

            sb.Append("}");
            return sb.ToString();
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Type
        {
            initial_feed,
            live_feed,
            market_info
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum RequestMode
        {
            ltpc,
            full_d5,
            option_greeks,
            full_d30
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum MarketStatus
        {
            PRE_OPEN_START,
            PRE_OPEN_END,
            NORMAL_OPEN,
            NORMAL_CLOSE,
            CLOSING_START,
            CLOSING_END
        }

        public class LTPC
        {
            [JsonPropertyName("ltp")]
            public double? Ltp { get; set; }

            [JsonPropertyName("ltt")]
            public long? Ltt { get; set; }

            [JsonPropertyName("ltq")]
            public long? Ltq { get; set; }

            [JsonPropertyName("cp")]
            public double? Cp { get; set; }

            public override string ToString()
            {
                return $"LTPC {{ Ltp: {Ltp}, Ltt: {Ltt}, Ltq: {Ltq}, Cp: {Cp} }}";
            }
        }

        public class MarketLevel
        {
            [JsonPropertyName("bidAskQuote")]
            public List<Quote>? BidAskQuote { get; set; }

            public override string ToString()
            {
                var quotes = BidAskQuote != null ?
                    string.Join(", ", BidAskQuote.Select(q => q?.ToString() ?? "null")) :
                    "null";
                return $"MarketLevel {{ BidAskQuote: [{quotes}] }}";
            }
        }

        public class MarketOHLC
        {
            [JsonPropertyName("ohlc")]
            public List<OHLC>? Ohlc { get; set; }

            public override string ToString()
            {
                var ohlc = Ohlc != null ?
                    string.Join(", ", Ohlc.Select(o => o?.ToString() ?? "null")) :
                    "null";
                return $"MarketOHLC {{ Ohlc: [{ohlc}] }}";
            }
        }

        public class Quote
        {
            [JsonPropertyName("bidQ")]
            public long? BidQ { get; set; }

            [JsonPropertyName("bidP")]
            public double? BidP { get; set; }

            [JsonPropertyName("askQ")]
            public long? AskQ { get; set; }

            [JsonPropertyName("askP")]
            public double? AskP { get; set; }

            public override string ToString()
            {
                return $"Quote {{ BidQ: {BidQ}, BidP: {BidP}, AskQ: {AskQ}, AskP: {AskP} }}";
            }
        }

        public class OptionGreeks
        {
            [JsonPropertyName("delta")]
            public double? Delta { get; set; }

            [JsonPropertyName("theta")]
            public double? Theta { get; set; }

            [JsonPropertyName("gamma")]
            public double? Gamma { get; set; }

            [JsonPropertyName("vega")]
            public double? Vega { get; set; }

            [JsonPropertyName("rho")]
            public double? Rho { get; set; }

            public override string ToString()
            {
                return $"OptionGreeks {{ Delta: {Delta}, Theta: {Theta}, Gamma: {Gamma}, Vega: {Vega}, Rho: {Rho} }}";
            }
        }

        public class OHLC
        {
            [JsonPropertyName("interval")]
            public string? Interval { get; set; }

            [JsonPropertyName("open")]
            public double? Open { get; set; }

            [JsonPropertyName("high")]
            public double? High { get; set; }

            [JsonPropertyName("low")]
            public double? Low { get; set; }

            [JsonPropertyName("close")]
            public double? Close { get; set; }

            [JsonPropertyName("vol")]
            public long? Vol { get; set; }

            [JsonPropertyName("ts")]
            public long? Ts { get; set; }

            public override string ToString()
            {
                return $"OHLC {{ Interval: {Interval}, Open: {Open}, High: {High}, Low: {Low}, Close: {Close}, Vol: {Vol}, Ts: {Ts} }}";
            }
        }

        public class MarketFullFeed
        {
            [JsonPropertyName("ltpc")]
            public LTPC? Ltpc { get; set; }

            [JsonPropertyName("marketLevel")]
            public MarketLevel? MarketLevel { get; set; }

            [JsonPropertyName("optionGreeks")]
            public OptionGreeks? OptionGreeks { get; set; }

            [JsonPropertyName("marketOHLC")]
            public MarketOHLC? MarketOHLC { get; set; }

            [JsonPropertyName("atp")]
            public double? Atp { get; set; }

            [JsonPropertyName("vtt")]
            public long? Vtt { get; set; }

            [JsonPropertyName("oi")]
            public double? Oi { get; set; }

            [JsonPropertyName("iv")]
            public double? Iv { get; set; }

            [JsonPropertyName("tbq")]
            public double? Tbq { get; set; }

            [JsonPropertyName("tsq")]
            public double? Tsq { get; set; }

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.Append("MarketFullFeed { ");
                sb.Append($"Ltpc: {Ltpc?.ToString() ?? "null"}, ");
                sb.Append($"MarketLevel: {MarketLevel?.ToString() ?? "null"}, ");
                sb.Append($"OptionGreeks: {OptionGreeks?.ToString() ?? "null"}, ");
                sb.Append($"MarketOHLC: {MarketOHLC?.ToString() ?? "null"}, ");
                sb.Append($"Atp: {Atp}, Vtt: {Vtt}, Oi: {Oi}, Iv: {Iv}, Tbq: {Tbq}, Tsq: {Tsq} ");
                sb.Append("}");
                return sb.ToString();
            }
        }

        public class IndexFullFeed
        {
            [JsonPropertyName("ltpc")]
            public LTPC? Ltpc { get; set; }

            [JsonPropertyName("marketOHLC")]
            public MarketOHLC? MarketOHLC { get; set; }

            public override string ToString()
            {
                return $"IndexFullFeed {{ Ltpc: {Ltpc?.ToString() ?? "null"}, MarketOHLC: {MarketOHLC?.ToString() ?? "null"} }}";
            }
        }

        public class FullFeed
        {
            [JsonPropertyName("marketFF")]
            public MarketFullFeed? MarketFF { get; set; }

            [JsonPropertyName("indexFF")]
            public IndexFullFeed? IndexFF { get; set; }

            public override string ToString()
            {
                return $"FullFeed {{ MarketFF: {MarketFF?.ToString() ?? "null"}, IndexFF: {IndexFF?.ToString() ?? "null"} }}";
            }
        }

        public class FirstLevelWithGreeks
        {
            [JsonPropertyName("ltpc")]
            public LTPC? Ltpc { get; set; }

            [JsonPropertyName("firstDepth")]
            public Quote? FirstDepth { get; set; }

            [JsonPropertyName("optionGreeks")]
            public OptionGreeks? OptionGreeks { get; set; }

            [JsonPropertyName("vtt")]
            public long? Vtt { get; set; }

            [JsonPropertyName("oi")]
            public double? Oi { get; set; }

            [JsonPropertyName("iv")]
            public double? Iv { get; set; }

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.Append("FirstLevelWithGreeks { ");
                sb.Append($"Ltpc: {Ltpc?.ToString() ?? "null"}, ");
                sb.Append($"FirstDepth: {FirstDepth?.ToString() ?? "null"}, ");
                sb.Append($"OptionGreeks: {OptionGreeks?.ToString() ?? "null"}, ");
                sb.Append($"Vtt: {Vtt}, Oi: {Oi}, Iv: {Iv} ");
                sb.Append("}");
                return sb.ToString();
            }
        }

        public class Feed
        {
            [JsonPropertyName("ltpc")]
            public LTPC? Ltpc { get; set; }

            [JsonPropertyName("fullFeed")]
            public FullFeed? FullFeed { get; set; }

            [JsonPropertyName("firstLevelWithGreeks")]
            public FirstLevelWithGreeks? FirstLevelWithGreeks { get; set; }

            [JsonPropertyName("requestMode")]
            public RequestMode? Mode { get; set; }

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.Append("Feed { ");
                sb.Append($"Ltpc: {Ltpc?.ToString() ?? "null"}, ");
                sb.Append($"FullFeed: {FullFeed?.ToString() ?? "null"}, ");
                sb.Append($"FirstLevelWithGreeks: {FirstLevelWithGreeks?.ToString() ?? "null"}, ");
                sb.Append($"Mode: {Mode} ");
                sb.Append("}");
                return sb.ToString();
            }
        }

        public class MarketInfo
        {
            [JsonPropertyName("segmentStatus")]
            public Dictionary<string, MarketStatus>? SegmentStatus { get; set; }

            public override string ToString()
            {
                if (SegmentStatus == null || SegmentStatus.Count == 0)
                {
                    return "MarketInfo { SegmentStatus: null }";
                }

                var statusString = string.Join(", ", SegmentStatus.Select(s => $"\"{s.Key}\": {s.Value}"));
                return $"MarketInfo {{ SegmentStatus: {{ {statusString} }} }}";
            }
        }
    }
}
