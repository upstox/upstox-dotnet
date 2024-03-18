using System;
using System.Collections.Generic;

namespace UpstoxClient.Feeder
{
    public class MarketUpdate
    {
        public Type Type { get; set; }
        public Dictionary<string, Feed> Feeds { get; set; }

    }

    public class LTPC
    {
        public double Ltp { get; set; }
        public long Ltt { get; set; }
        public long Ltq { get; set; }
        public double Cp { get; set; } // close price

        public override string ToString()
        {
            return string.Format("LTPC: Ltp={0}, Ltt={1}, Ltq={2}, Cp={3}", Ltp, Ltt, Ltq, Cp);
        }

    }

    public class Quote
    {
        public int Bq { get; set; } // bid quantity
        public double Bp { get; set; } // bid price
        public int Bno { get; set; } // bid number of orders
        public int Aq { get; set; } // ask quantity
        public double Ap { get; set; } // ask price
        public int Ano { get; set; } // ask number of orders
    }

    public class OptionGreeks
    {
        public double Op { get; set; }
        public double Up { get; set; }
        public double Iv { get; set; }
        public double Delta { get; set; }
        public double Theta { get; set; }
        public double Gamma { get; set; }
        public double Vega { get; set; }
        public double Rho { get; set; }
    }

    public class OHLC
    {
        public string Interval { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public int Volume { get; set; }
        public long Ts { get; set; }

    }

    public class MarketLevel
    {
        public List<Quote> BidAskQuote { get; set; }
    }

    public class MarketOHLC
    {
        public List<OHLC> Ohlc { get; set; }
    }

    public class ExtendedFeedDetails
    {
        public double Atp { get; set; } // Average traded price
        public double Cp { get; set; } // Close price
        public long Vtt { get; set; } // Volume traded today
        public double Oi { get; set; } // Open interest
        public double ChangeOi { get; set; } // Change in open interest
        public double LastClose { get; set; } // Last closing price
        public double Tbq { get; set; } // Total buy quantity
        public double Tsq { get; set; } // Total sell quantity
        public double Close { get; set; } // Close price
        public double Lc { get; set; } // Lower circuit limit
        public double Uc { get; set; } // Upper circuit limit
        public double Yh { get; set; } // Yearly high
        public double Yl { get; set; } // Yearly low
        public double Fp { get; set; } // Fill price
        public int Fv { get; set; } // Fill volume
        public long MbpBuy { get; set; } // Market Best Price (Buy)
        public long MbpSell { get; set; } // Market Best Price (Sell)
        public long Tv { get; set; } // Traded volume
        public double Dhoi { get; set; } // Day high open interest
        public double Dloi { get; set; } // Day low open interest
        public double Sp { get; set; } // Spot price
        public double Poi { get; set; } // Previous open interest
    }


    public class FullFeed
    {
        public MarketFullFeed MarketFF { get; set; }
        public IndexFullFeed IndexFF { get; set; }

    }

    public class IndexFullFeed
    {
        public LTPC Ltpc { get; set; }
        public MarketOHLC MarketOHLC { get; set; }
        public double LastClose { get; set; }
        public double Yh { get; set; } // Yearly high
        public double Yl { get; set; } // Yearly low

    }

    public class MarketFullFeed
    {
        public LTPC Ltpc { get; set; }
        public MarketLevel MarketLevel { get; set; }
        public OptionGreeks OptionGreeks { get; set; }
        public MarketOHLC MarketOHLC { get; set; }
        public ExtendedFeedDetails EFeedDetails { get; set; }

    }

    public class OptionChain
    {
        public LTPC Ltpc { get; set; }
        public Quote BidAskQuote { get; set; }
        public OptionGreeks OptionGreeks { get; set; }
        public ExtendedFeedDetails EFeedDetails { get; set; }

    }

    public class Feed
    {
        public LTPC Ltpc { get; set; }
        public FullFeed Ff { get; set; }
        public OptionChain Oc { get; set; }

    }

    public enum Type
    {
        initial_feed, live_feed
    }

}
