/* 
 * OpenAPI definition
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = UpstoxClient.Client.SwaggerDateConverter;
namespace UpstoxClient.Model
{
    /// <summary>
    /// Response data for position details
    /// </summary>
    [DataContract]
        public partial class PositionData :  IEquatable<PositionData>, IValidatableObject
    {
        /// <summary>
        /// Exchange to which the order is associated
        /// </summary>
        /// <value>Exchange to which the order is associated</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum ExchangeEnum
        {
            /// <summary>
            /// Enum NSE for value: NSE
            /// </summary>
            [EnumMember(Value = "NSE")]
            NSE = 1,
            /// <summary>
            /// Enum NFO for value: NFO
            /// </summary>
            [EnumMember(Value = "NFO")]
            NFO = 2,
            /// <summary>
            /// Enum CDS for value: CDS
            /// </summary>
            [EnumMember(Value = "CDS")]
            CDS = 3,
            /// <summary>
            /// Enum BSE for value: BSE
            /// </summary>
            [EnumMember(Value = "BSE")]
            BSE = 4,
            /// <summary>
            /// Enum BFO for value: BFO
            /// </summary>
            [EnumMember(Value = "BFO")]
            BFO = 5,
            /// <summary>
            /// Enum BCD for value: BCD
            /// </summary>
            [EnumMember(Value = "BCD")]
            BCD = 6,
            /// <summary>
            /// Enum MCX for value: MCX
            /// </summary>
            [EnumMember(Value = "MCX")]
            MCX = 7        }
        /// <summary>
        /// Exchange to which the order is associated
        /// </summary>
        /// <value>Exchange to which the order is associated</value>
        [DataMember(Name="exchange", EmitDefaultValue=false)]
        public ExchangeEnum? Exchange { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PositionData" /> class.
        /// </summary>
        public PositionData()
        {
        }
        

        /// <summary>
        /// The quantity/lot size multiplier used for calculating P&amp;Ls
        /// </summary>
        /// <value>The quantity/lot size multiplier used for calculating P&amp;Ls</value>
        [DataMember(Name="multiplier", EmitDefaultValue=false)]
        public float? Multiplier { get; private set; }

        /// <summary>
        /// Net value of the position
        /// </summary>
        /// <value>Net value of the position</value>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public float? Value { get; private set; }

        /// <summary>
        /// Profit and loss - net returns on the position
        /// </summary>
        /// <value>Profit and loss - net returns on the position</value>
        [DataMember(Name="pnl", EmitDefaultValue=false)]
        public float? Pnl { get; private set; }

        /// <summary>
        /// Shows if the order was either Intraday, Delivery, CO or OCO
        /// </summary>
        /// <value>Shows if the order was either Intraday, Delivery, CO or OCO</value>
        [DataMember(Name="product", EmitDefaultValue=false)]
        public string Product { get; private set; }

        /// <summary>
        /// Key issued by Upstox for the instrument
        /// </summary>
        /// <value>Key issued by Upstox for the instrument</value>
        [DataMember(Name="instrument_token", EmitDefaultValue=false)]
        public string InstrumentToken { get; private set; }

        /// <summary>
        /// Average price at which the net position quantity was acquired
        /// </summary>
        /// <value>Average price at which the net position quantity was acquired</value>
        [DataMember(Name="average_price", EmitDefaultValue=false)]
        public float? AveragePrice { get; private set; }

        /// <summary>
        /// Net value of the bought quantities
        /// </summary>
        /// <value>Net value of the bought quantities</value>
        [DataMember(Name="buy_value", EmitDefaultValue=false)]
        public float? BuyValue { get; private set; }

        /// <summary>
        /// Quantity held previously and carried forward over night
        /// </summary>
        /// <value>Quantity held previously and carried forward over night</value>
        [DataMember(Name="overnight_quantity", EmitDefaultValue=false)]
        public int? OvernightQuantity { get; private set; }

        /// <summary>
        /// Amount at which the quantity is bought during the day
        /// </summary>
        /// <value>Amount at which the quantity is bought during the day</value>
        [DataMember(Name="day_buy_value", EmitDefaultValue=false)]
        public float? DayBuyValue { get; private set; }

        /// <summary>
        /// Average price at which the day qty was bought. Default is empty string
        /// </summary>
        /// <value>Average price at which the day qty was bought. Default is empty string</value>
        [DataMember(Name="day_buy_price", EmitDefaultValue=false)]
        public float? DayBuyPrice { get; private set; }

        /// <summary>
        /// Amount at which the quantity was bought in the previous session
        /// </summary>
        /// <value>Amount at which the quantity was bought in the previous session</value>
        [DataMember(Name="overnight_buy_amount", EmitDefaultValue=false)]
        public float? OvernightBuyAmount { get; private set; }

        /// <summary>
        /// Quantity bought in the previous session
        /// </summary>
        /// <value>Quantity bought in the previous session</value>
        [DataMember(Name="overnight_buy_quantity", EmitDefaultValue=false)]
        public int? OvernightBuyQuantity { get; private set; }

        /// <summary>
        /// Quantity bought during the day
        /// </summary>
        /// <value>Quantity bought during the day</value>
        [DataMember(Name="day_buy_quantity", EmitDefaultValue=false)]
        public int? DayBuyQuantity { get; private set; }

        /// <summary>
        /// Amount at which the quantity is sold during the day
        /// </summary>
        /// <value>Amount at which the quantity is sold during the day</value>
        [DataMember(Name="day_sell_value", EmitDefaultValue=false)]
        public float? DaySellValue { get; private set; }

        /// <summary>
        /// Average price at which the day quantity was sold
        /// </summary>
        /// <value>Average price at which the day quantity was sold</value>
        [DataMember(Name="day_sell_price", EmitDefaultValue=false)]
        public float? DaySellPrice { get; private set; }

        /// <summary>
        /// Amount at which the quantity was sold in the previous session
        /// </summary>
        /// <value>Amount at which the quantity was sold in the previous session</value>
        [DataMember(Name="overnight_sell_amount", EmitDefaultValue=false)]
        public float? OvernightSellAmount { get; private set; }

        /// <summary>
        /// Quantity sold short in the previous session
        /// </summary>
        /// <value>Quantity sold short in the previous session</value>
        [DataMember(Name="overnight_sell_quantity", EmitDefaultValue=false)]
        public int? OvernightSellQuantity { get; private set; }

        /// <summary>
        /// Quantity sold during the day
        /// </summary>
        /// <value>Quantity sold during the day</value>
        [DataMember(Name="day_sell_quantity", EmitDefaultValue=false)]
        public int? DaySellQuantity { get; private set; }

        /// <summary>
        /// Quantity left after nullifying Day and CF buy quantity towards Day and CF sell quantity
        /// </summary>
        /// <value>Quantity left after nullifying Day and CF buy quantity towards Day and CF sell quantity</value>
        [DataMember(Name="quantity", EmitDefaultValue=false)]
        public int? Quantity { get; private set; }

        /// <summary>
        /// Last traded market price of the instrument
        /// </summary>
        /// <value>Last traded market price of the instrument</value>
        [DataMember(Name="last_price", EmitDefaultValue=false)]
        public float? LastPrice { get; private set; }

        /// <summary>
        /// Day PnL generated against open positions
        /// </summary>
        /// <value>Day PnL generated against open positions</value>
        [DataMember(Name="unrealised", EmitDefaultValue=false)]
        public float? Unrealised { get; private set; }

        /// <summary>
        /// Day PnL generated against closed positions
        /// </summary>
        /// <value>Day PnL generated against closed positions</value>
        [DataMember(Name="realised", EmitDefaultValue=false)]
        public float? Realised { get; private set; }

        /// <summary>
        /// Net value of the sold quantities
        /// </summary>
        /// <value>Net value of the sold quantities</value>
        [DataMember(Name="sell_value", EmitDefaultValue=false)]
        public float? SellValue { get; private set; }

        /// <summary>
        /// Shows the trading symbol of the instrument
        /// </summary>
        /// <value>Shows the trading symbol of the instrument</value>
        [DataMember(Name="tradingsymbol", EmitDefaultValue=false)]
        public string Tradingsymbol { get; private set; }

        /// <summary>
        /// Shows the trading symbol of the instrument
        /// </summary>
        /// <value>Shows the trading symbol of the instrument</value>
        [DataMember(Name="trading_symbol", EmitDefaultValue=false)]
        public string TradingSymbol { get; private set; }

        /// <summary>
        /// Closing price of the instrument from the last trading day
        /// </summary>
        /// <value>Closing price of the instrument from the last trading day</value>
        [DataMember(Name="close_price", EmitDefaultValue=false)]
        public float? ClosePrice { get; private set; }

        /// <summary>
        /// Average price at which quantities were bought
        /// </summary>
        /// <value>Average price at which quantities were bought</value>
        [DataMember(Name="buy_price", EmitDefaultValue=false)]
        public float? BuyPrice { get; private set; }

        /// <summary>
        /// Average price at which quantities were sold
        /// </summary>
        /// <value>Average price at which quantities were sold</value>
        [DataMember(Name="sell_price", EmitDefaultValue=false)]
        public float? SellPrice { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PositionData {\n");
            sb.Append("  Exchange: ").Append(Exchange).Append("\n");
            sb.Append("  Multiplier: ").Append(Multiplier).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Pnl: ").Append(Pnl).Append("\n");
            sb.Append("  Product: ").Append(Product).Append("\n");
            sb.Append("  InstrumentToken: ").Append(InstrumentToken).Append("\n");
            sb.Append("  AveragePrice: ").Append(AveragePrice).Append("\n");
            sb.Append("  BuyValue: ").Append(BuyValue).Append("\n");
            sb.Append("  OvernightQuantity: ").Append(OvernightQuantity).Append("\n");
            sb.Append("  DayBuyValue: ").Append(DayBuyValue).Append("\n");
            sb.Append("  DayBuyPrice: ").Append(DayBuyPrice).Append("\n");
            sb.Append("  OvernightBuyAmount: ").Append(OvernightBuyAmount).Append("\n");
            sb.Append("  OvernightBuyQuantity: ").Append(OvernightBuyQuantity).Append("\n");
            sb.Append("  DayBuyQuantity: ").Append(DayBuyQuantity).Append("\n");
            sb.Append("  DaySellValue: ").Append(DaySellValue).Append("\n");
            sb.Append("  DaySellPrice: ").Append(DaySellPrice).Append("\n");
            sb.Append("  OvernightSellAmount: ").Append(OvernightSellAmount).Append("\n");
            sb.Append("  OvernightSellQuantity: ").Append(OvernightSellQuantity).Append("\n");
            sb.Append("  DaySellQuantity: ").Append(DaySellQuantity).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  LastPrice: ").Append(LastPrice).Append("\n");
            sb.Append("  Unrealised: ").Append(Unrealised).Append("\n");
            sb.Append("  Realised: ").Append(Realised).Append("\n");
            sb.Append("  SellValue: ").Append(SellValue).Append("\n");
            sb.Append("  Tradingsymbol: ").Append(Tradingsymbol).Append("\n");
            sb.Append("  TradingSymbol: ").Append(TradingSymbol).Append("\n");
            sb.Append("  ClosePrice: ").Append(ClosePrice).Append("\n");
            sb.Append("  BuyPrice: ").Append(BuyPrice).Append("\n");
            sb.Append("  SellPrice: ").Append(SellPrice).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as PositionData);
        }

        /// <summary>
        /// Returns true if PositionData instances are equal
        /// </summary>
        /// <param name="input">Instance of PositionData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PositionData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Exchange == input.Exchange ||
                    (this.Exchange != null &&
                    this.Exchange.Equals(input.Exchange))
                ) && 
                (
                    this.Multiplier == input.Multiplier ||
                    (this.Multiplier != null &&
                    this.Multiplier.Equals(input.Multiplier))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) && 
                (
                    this.Pnl == input.Pnl ||
                    (this.Pnl != null &&
                    this.Pnl.Equals(input.Pnl))
                ) && 
                (
                    this.Product == input.Product ||
                    (this.Product != null &&
                    this.Product.Equals(input.Product))
                ) && 
                (
                    this.InstrumentToken == input.InstrumentToken ||
                    (this.InstrumentToken != null &&
                    this.InstrumentToken.Equals(input.InstrumentToken))
                ) && 
                (
                    this.AveragePrice == input.AveragePrice ||
                    (this.AveragePrice != null &&
                    this.AveragePrice.Equals(input.AveragePrice))
                ) && 
                (
                    this.BuyValue == input.BuyValue ||
                    (this.BuyValue != null &&
                    this.BuyValue.Equals(input.BuyValue))
                ) && 
                (
                    this.OvernightQuantity == input.OvernightQuantity ||
                    (this.OvernightQuantity != null &&
                    this.OvernightQuantity.Equals(input.OvernightQuantity))
                ) && 
                (
                    this.DayBuyValue == input.DayBuyValue ||
                    (this.DayBuyValue != null &&
                    this.DayBuyValue.Equals(input.DayBuyValue))
                ) && 
                (
                    this.DayBuyPrice == input.DayBuyPrice ||
                    (this.DayBuyPrice != null &&
                    this.DayBuyPrice.Equals(input.DayBuyPrice))
                ) && 
                (
                    this.OvernightBuyAmount == input.OvernightBuyAmount ||
                    (this.OvernightBuyAmount != null &&
                    this.OvernightBuyAmount.Equals(input.OvernightBuyAmount))
                ) && 
                (
                    this.OvernightBuyQuantity == input.OvernightBuyQuantity ||
                    (this.OvernightBuyQuantity != null &&
                    this.OvernightBuyQuantity.Equals(input.OvernightBuyQuantity))
                ) && 
                (
                    this.DayBuyQuantity == input.DayBuyQuantity ||
                    (this.DayBuyQuantity != null &&
                    this.DayBuyQuantity.Equals(input.DayBuyQuantity))
                ) && 
                (
                    this.DaySellValue == input.DaySellValue ||
                    (this.DaySellValue != null &&
                    this.DaySellValue.Equals(input.DaySellValue))
                ) && 
                (
                    this.DaySellPrice == input.DaySellPrice ||
                    (this.DaySellPrice != null &&
                    this.DaySellPrice.Equals(input.DaySellPrice))
                ) && 
                (
                    this.OvernightSellAmount == input.OvernightSellAmount ||
                    (this.OvernightSellAmount != null &&
                    this.OvernightSellAmount.Equals(input.OvernightSellAmount))
                ) && 
                (
                    this.OvernightSellQuantity == input.OvernightSellQuantity ||
                    (this.OvernightSellQuantity != null &&
                    this.OvernightSellQuantity.Equals(input.OvernightSellQuantity))
                ) && 
                (
                    this.DaySellQuantity == input.DaySellQuantity ||
                    (this.DaySellQuantity != null &&
                    this.DaySellQuantity.Equals(input.DaySellQuantity))
                ) && 
                (
                    this.Quantity == input.Quantity ||
                    (this.Quantity != null &&
                    this.Quantity.Equals(input.Quantity))
                ) && 
                (
                    this.LastPrice == input.LastPrice ||
                    (this.LastPrice != null &&
                    this.LastPrice.Equals(input.LastPrice))
                ) && 
                (
                    this.Unrealised == input.Unrealised ||
                    (this.Unrealised != null &&
                    this.Unrealised.Equals(input.Unrealised))
                ) && 
                (
                    this.Realised == input.Realised ||
                    (this.Realised != null &&
                    this.Realised.Equals(input.Realised))
                ) && 
                (
                    this.SellValue == input.SellValue ||
                    (this.SellValue != null &&
                    this.SellValue.Equals(input.SellValue))
                ) && 
                (
                    this.Tradingsymbol == input.Tradingsymbol ||
                    (this.Tradingsymbol != null &&
                    this.Tradingsymbol.Equals(input.Tradingsymbol))
                ) && 
                (
                    this.TradingSymbol == input.TradingSymbol ||
                    (this.TradingSymbol != null &&
                    this.TradingSymbol.Equals(input.TradingSymbol))
                ) && 
                (
                    this.ClosePrice == input.ClosePrice ||
                    (this.ClosePrice != null &&
                    this.ClosePrice.Equals(input.ClosePrice))
                ) && 
                (
                    this.BuyPrice == input.BuyPrice ||
                    (this.BuyPrice != null &&
                    this.BuyPrice.Equals(input.BuyPrice))
                ) && 
                (
                    this.SellPrice == input.SellPrice ||
                    (this.SellPrice != null &&
                    this.SellPrice.Equals(input.SellPrice))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Exchange != null)
                    hashCode = hashCode * 59 + this.Exchange.GetHashCode();
                if (this.Multiplier != null)
                    hashCode = hashCode * 59 + this.Multiplier.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                if (this.Pnl != null)
                    hashCode = hashCode * 59 + this.Pnl.GetHashCode();
                if (this.Product != null)
                    hashCode = hashCode * 59 + this.Product.GetHashCode();
                if (this.InstrumentToken != null)
                    hashCode = hashCode * 59 + this.InstrumentToken.GetHashCode();
                if (this.AveragePrice != null)
                    hashCode = hashCode * 59 + this.AveragePrice.GetHashCode();
                if (this.BuyValue != null)
                    hashCode = hashCode * 59 + this.BuyValue.GetHashCode();
                if (this.OvernightQuantity != null)
                    hashCode = hashCode * 59 + this.OvernightQuantity.GetHashCode();
                if (this.DayBuyValue != null)
                    hashCode = hashCode * 59 + this.DayBuyValue.GetHashCode();
                if (this.DayBuyPrice != null)
                    hashCode = hashCode * 59 + this.DayBuyPrice.GetHashCode();
                if (this.OvernightBuyAmount != null)
                    hashCode = hashCode * 59 + this.OvernightBuyAmount.GetHashCode();
                if (this.OvernightBuyQuantity != null)
                    hashCode = hashCode * 59 + this.OvernightBuyQuantity.GetHashCode();
                if (this.DayBuyQuantity != null)
                    hashCode = hashCode * 59 + this.DayBuyQuantity.GetHashCode();
                if (this.DaySellValue != null)
                    hashCode = hashCode * 59 + this.DaySellValue.GetHashCode();
                if (this.DaySellPrice != null)
                    hashCode = hashCode * 59 + this.DaySellPrice.GetHashCode();
                if (this.OvernightSellAmount != null)
                    hashCode = hashCode * 59 + this.OvernightSellAmount.GetHashCode();
                if (this.OvernightSellQuantity != null)
                    hashCode = hashCode * 59 + this.OvernightSellQuantity.GetHashCode();
                if (this.DaySellQuantity != null)
                    hashCode = hashCode * 59 + this.DaySellQuantity.GetHashCode();
                if (this.Quantity != null)
                    hashCode = hashCode * 59 + this.Quantity.GetHashCode();
                if (this.LastPrice != null)
                    hashCode = hashCode * 59 + this.LastPrice.GetHashCode();
                if (this.Unrealised != null)
                    hashCode = hashCode * 59 + this.Unrealised.GetHashCode();
                if (this.Realised != null)
                    hashCode = hashCode * 59 + this.Realised.GetHashCode();
                if (this.SellValue != null)
                    hashCode = hashCode * 59 + this.SellValue.GetHashCode();
                if (this.Tradingsymbol != null)
                    hashCode = hashCode * 59 + this.Tradingsymbol.GetHashCode();
                if (this.TradingSymbol != null)
                    hashCode = hashCode * 59 + this.TradingSymbol.GetHashCode();
                if (this.ClosePrice != null)
                    hashCode = hashCode * 59 + this.ClosePrice.GetHashCode();
                if (this.BuyPrice != null)
                    hashCode = hashCode * 59 + this.BuyPrice.GetHashCode();
                if (this.SellPrice != null)
                    hashCode = hashCode * 59 + this.SellPrice.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
