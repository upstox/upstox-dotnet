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
    /// MultiOrderRequest
    /// </summary>
    [DataContract]
        public partial class MultiOrderRequest :  IEquatable<MultiOrderRequest>, IValidatableObject
    {
        /// <summary>
        /// Signifies if the order was either Intraday, Delivery, CO or OCO
        /// </summary>
        /// <value>Signifies if the order was either Intraday, Delivery, CO or OCO</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum ProductEnum
        {
            /// <summary>
            /// Enum I for value: I
            /// </summary>
            [EnumMember(Value = "I")]
            I = 1,
            /// <summary>
            /// Enum D for value: D
            /// </summary>
            [EnumMember(Value = "D")]
            D = 2        }
        /// <summary>
        /// Signifies if the order was either Intraday, Delivery, CO or OCO
        /// </summary>
        /// <value>Signifies if the order was either Intraday, Delivery, CO or OCO</value>
        [DataMember(Name="product", EmitDefaultValue=false)]
        public ProductEnum Product { get; set; }
        /// <summary>
        /// It can be one of the following - DAY(default), IOC
        /// </summary>
        /// <value>It can be one of the following - DAY(default), IOC</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum ValidityEnum
        {
            /// <summary>
            /// Enum DAY for value: DAY
            /// </summary>
            [EnumMember(Value = "DAY")]
            DAY = 1,
            /// <summary>
            /// Enum IOC for value: IOC
            /// </summary>
            [EnumMember(Value = "IOC")]
            IOC = 2        }
        /// <summary>
        /// It can be one of the following - DAY(default), IOC
        /// </summary>
        /// <value>It can be one of the following - DAY(default), IOC</value>
        [DataMember(Name="validity", EmitDefaultValue=false)]
        public ValidityEnum Validity { get; set; }
        /// <summary>
        /// Type of order. It can be one of the following MARKET refers to market order LIMIT refers to Limit Order SL refers to Stop Loss Limit SL-M refers to Stop Loss Market
        /// </summary>
        /// <value>Type of order. It can be one of the following MARKET refers to market order LIMIT refers to Limit Order SL refers to Stop Loss Limit SL-M refers to Stop Loss Market</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum OrderTypeEnum
        {
            /// <summary>
            /// Enum MARKET for value: MARKET
            /// </summary>
            [EnumMember(Value = "MARKET")]
            MARKET = 1,
            /// <summary>
            /// Enum LIMIT for value: LIMIT
            /// </summary>
            [EnumMember(Value = "LIMIT")]
            LIMIT = 2,
            /// <summary>
            /// Enum SL for value: SL
            /// </summary>
            [EnumMember(Value = "SL")]
            SL = 3,
            /// <summary>
            /// Enum SLM for value: SL-M
            /// </summary>
            [EnumMember(Value = "SL-M")]
            SLM = 4        }
        /// <summary>
        /// Type of order. It can be one of the following MARKET refers to market order LIMIT refers to Limit Order SL refers to Stop Loss Limit SL-M refers to Stop Loss Market
        /// </summary>
        /// <value>Type of order. It can be one of the following MARKET refers to market order LIMIT refers to Limit Order SL refers to Stop Loss Limit SL-M refers to Stop Loss Market</value>
        [DataMember(Name="order_type", EmitDefaultValue=false)]
        public OrderTypeEnum OrderType { get; set; }
        /// <summary>
        /// Indicates whether its a buy or sell order
        /// </summary>
        /// <value>Indicates whether its a buy or sell order</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum TransactionTypeEnum
        {
            /// <summary>
            /// Enum BUY for value: BUY
            /// </summary>
            [EnumMember(Value = "BUY")]
            BUY = 1,
            /// <summary>
            /// Enum SELL for value: SELL
            /// </summary>
            [EnumMember(Value = "SELL")]
            SELL = 2        }
        /// <summary>
        /// Indicates whether its a buy or sell order
        /// </summary>
        /// <value>Indicates whether its a buy or sell order</value>
        [DataMember(Name="transaction_type", EmitDefaultValue=false)]
        public TransactionTypeEnum TransactionType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiOrderRequest" /> class.
        /// </summary>
        /// <param name="quantity">Quantity with which the order is to be placed (required).</param>
        /// <param name="product">Signifies if the order was either Intraday, Delivery, CO or OCO (required).</param>
        /// <param name="validity">It can be one of the following - DAY(default), IOC (required).</param>
        /// <param name="price">Price at which the order will be placed (required).</param>
        /// <param name="tag">tag.</param>
        /// <param name="slice">To divide the order line based on predefined exchange definitions (required).</param>
        /// <param name="instrumentToken">Key of the instrument (required).</param>
        /// <param name="orderType">Type of order. It can be one of the following MARKET refers to market order LIMIT refers to Limit Order SL refers to Stop Loss Limit SL-M refers to Stop Loss Market (required).</param>
        /// <param name="transactionType">Indicates whether its a buy or sell order (required).</param>
        /// <param name="disclosedQuantity">The quantity that should be disclosed in the market depth (required).</param>
        /// <param name="triggerPrice">If the order is a stop loss order then the trigger price to be set is mentioned here (required).</param>
        /// <param name="isAmo">Signifies if the order is an After Market Order (required).</param>
        /// <param name="correlationId">A unique identifier for tracking individual orders within the batch (required).</param>
        public MultiOrderRequest(int? quantity = default(int?), ProductEnum product = default(ProductEnum), ValidityEnum validity = default(ValidityEnum), float? price = default(float?), string tag = default(string), bool? slice = default(bool?), string instrumentToken = default(string), OrderTypeEnum orderType = default(OrderTypeEnum), TransactionTypeEnum transactionType = default(TransactionTypeEnum), int? disclosedQuantity = default(int?), float? triggerPrice = default(float?), bool? isAmo = default(bool?), string correlationId = default(string))
        {
            // to ensure "quantity" is required (not null)
            if (quantity == null)
            {
                throw new InvalidDataException("quantity is a required property for MultiOrderRequest and cannot be null");
            }
            else
            {
                this.Quantity = quantity;
            }
            // to ensure "product" is required (not null)
            if (product == null)
            {
                throw new InvalidDataException("product is a required property for MultiOrderRequest and cannot be null");
            }
            else
            {
                this.Product = product;
            }
            // to ensure "validity" is required (not null)
            if (validity == null)
            {
                throw new InvalidDataException("validity is a required property for MultiOrderRequest and cannot be null");
            }
            else
            {
                this.Validity = validity;
            }
            // to ensure "price" is required (not null)
            if (price == null)
            {
                throw new InvalidDataException("price is a required property for MultiOrderRequest and cannot be null");
            }
            else
            {
                this.Price = price;
            }
            // to ensure "slice" is required (not null)
            if (slice == null)
            {
                throw new InvalidDataException("slice is a required property for MultiOrderRequest and cannot be null");
            }
            else
            {
                this.Slice = slice;
            }
            // to ensure "instrumentToken" is required (not null)
            if (instrumentToken == null)
            {
                throw new InvalidDataException("instrumentToken is a required property for MultiOrderRequest and cannot be null");
            }
            else
            {
                this.InstrumentToken = instrumentToken;
            }
            // to ensure "orderType" is required (not null)
            if (orderType == null)
            {
                throw new InvalidDataException("orderType is a required property for MultiOrderRequest and cannot be null");
            }
            else
            {
                this.OrderType = orderType;
            }
            // to ensure "transactionType" is required (not null)
            if (transactionType == null)
            {
                throw new InvalidDataException("transactionType is a required property for MultiOrderRequest and cannot be null");
            }
            else
            {
                this.TransactionType = transactionType;
            }
            // to ensure "disclosedQuantity" is required (not null)
            if (disclosedQuantity == null)
            {
                throw new InvalidDataException("disclosedQuantity is a required property for MultiOrderRequest and cannot be null");
            }
            else
            {
                this.DisclosedQuantity = disclosedQuantity;
            }
            // to ensure "triggerPrice" is required (not null)
            if (triggerPrice == null)
            {
                throw new InvalidDataException("triggerPrice is a required property for MultiOrderRequest and cannot be null");
            }
            else
            {
                this.TriggerPrice = triggerPrice;
            }
            // to ensure "isAmo" is required (not null)
            if (isAmo == null)
            {
                throw new InvalidDataException("isAmo is a required property for MultiOrderRequest and cannot be null");
            }
            else
            {
                this.IsAmo = isAmo;
            }
            // to ensure "correlationId" is required (not null)
            if (correlationId == null)
            {
                throw new InvalidDataException("correlationId is a required property for MultiOrderRequest and cannot be null");
            }
            else
            {
                this.CorrelationId = correlationId;
            }
            this.Tag = tag;
        }
        
        /// <summary>
        /// Quantity with which the order is to be placed
        /// </summary>
        /// <value>Quantity with which the order is to be placed</value>
        [DataMember(Name="quantity", EmitDefaultValue=false)]
        public int? Quantity { get; set; }



        /// <summary>
        /// Price at which the order will be placed
        /// </summary>
        /// <value>Price at which the order will be placed</value>
        [DataMember(Name="price", EmitDefaultValue=false)]
        public float? Price { get; set; }

        /// <summary>
        /// Gets or Sets Tag
        /// </summary>
        [DataMember(Name="tag", EmitDefaultValue=false)]
        public string Tag { get; set; }

        /// <summary>
        /// To divide the order line based on predefined exchange definitions
        /// </summary>
        /// <value>To divide the order line based on predefined exchange definitions</value>
        [DataMember(Name="slice", EmitDefaultValue=false)]
        public bool? Slice { get; set; }

        /// <summary>
        /// Key of the instrument
        /// </summary>
        /// <value>Key of the instrument</value>
        [DataMember(Name="instrument_token", EmitDefaultValue=false)]
        public string InstrumentToken { get; set; }



        /// <summary>
        /// The quantity that should be disclosed in the market depth
        /// </summary>
        /// <value>The quantity that should be disclosed in the market depth</value>
        [DataMember(Name="disclosed_quantity", EmitDefaultValue=false)]
        public int? DisclosedQuantity { get; set; }

        /// <summary>
        /// If the order is a stop loss order then the trigger price to be set is mentioned here
        /// </summary>
        /// <value>If the order is a stop loss order then the trigger price to be set is mentioned here</value>
        [DataMember(Name="trigger_price", EmitDefaultValue=false)]
        public float? TriggerPrice { get; set; }

        /// <summary>
        /// Signifies if the order is an After Market Order
        /// </summary>
        /// <value>Signifies if the order is an After Market Order</value>
        [DataMember(Name="is_amo", EmitDefaultValue=false)]
        public bool? IsAmo { get; set; }

        /// <summary>
        /// A unique identifier for tracking individual orders within the batch
        /// </summary>
        /// <value>A unique identifier for tracking individual orders within the batch</value>
        [DataMember(Name="correlation_id", EmitDefaultValue=false)]
        public string CorrelationId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MultiOrderRequest {\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  Product: ").Append(Product).Append("\n");
            sb.Append("  Validity: ").Append(Validity).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Tag: ").Append(Tag).Append("\n");
            sb.Append("  Slice: ").Append(Slice).Append("\n");
            sb.Append("  InstrumentToken: ").Append(InstrumentToken).Append("\n");
            sb.Append("  OrderType: ").Append(OrderType).Append("\n");
            sb.Append("  TransactionType: ").Append(TransactionType).Append("\n");
            sb.Append("  DisclosedQuantity: ").Append(DisclosedQuantity).Append("\n");
            sb.Append("  TriggerPrice: ").Append(TriggerPrice).Append("\n");
            sb.Append("  IsAmo: ").Append(IsAmo).Append("\n");
            sb.Append("  CorrelationId: ").Append(CorrelationId).Append("\n");
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
            return this.Equals(input as MultiOrderRequest);
        }

        /// <summary>
        /// Returns true if MultiOrderRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of MultiOrderRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MultiOrderRequest input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Quantity == input.Quantity ||
                    (this.Quantity != null &&
                    this.Quantity.Equals(input.Quantity))
                ) && 
                (
                    this.Product == input.Product ||
                    (this.Product != null &&
                    this.Product.Equals(input.Product))
                ) && 
                (
                    this.Validity == input.Validity ||
                    (this.Validity != null &&
                    this.Validity.Equals(input.Validity))
                ) && 
                (
                    this.Price == input.Price ||
                    (this.Price != null &&
                    this.Price.Equals(input.Price))
                ) && 
                (
                    this.Tag == input.Tag ||
                    (this.Tag != null &&
                    this.Tag.Equals(input.Tag))
                ) && 
                (
                    this.Slice == input.Slice ||
                    (this.Slice != null &&
                    this.Slice.Equals(input.Slice))
                ) && 
                (
                    this.InstrumentToken == input.InstrumentToken ||
                    (this.InstrumentToken != null &&
                    this.InstrumentToken.Equals(input.InstrumentToken))
                ) && 
                (
                    this.OrderType == input.OrderType ||
                    (this.OrderType != null &&
                    this.OrderType.Equals(input.OrderType))
                ) && 
                (
                    this.TransactionType == input.TransactionType ||
                    (this.TransactionType != null &&
                    this.TransactionType.Equals(input.TransactionType))
                ) && 
                (
                    this.DisclosedQuantity == input.DisclosedQuantity ||
                    (this.DisclosedQuantity != null &&
                    this.DisclosedQuantity.Equals(input.DisclosedQuantity))
                ) && 
                (
                    this.TriggerPrice == input.TriggerPrice ||
                    (this.TriggerPrice != null &&
                    this.TriggerPrice.Equals(input.TriggerPrice))
                ) && 
                (
                    this.IsAmo == input.IsAmo ||
                    (this.IsAmo != null &&
                    this.IsAmo.Equals(input.IsAmo))
                ) && 
                (
                    this.CorrelationId == input.CorrelationId ||
                    (this.CorrelationId != null &&
                    this.CorrelationId.Equals(input.CorrelationId))
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
                if (this.Quantity != null)
                    hashCode = hashCode * 59 + this.Quantity.GetHashCode();
                if (this.Product != null)
                    hashCode = hashCode * 59 + this.Product.GetHashCode();
                if (this.Validity != null)
                    hashCode = hashCode * 59 + this.Validity.GetHashCode();
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.Tag != null)
                    hashCode = hashCode * 59 + this.Tag.GetHashCode();
                if (this.Slice != null)
                    hashCode = hashCode * 59 + this.Slice.GetHashCode();
                if (this.InstrumentToken != null)
                    hashCode = hashCode * 59 + this.InstrumentToken.GetHashCode();
                if (this.OrderType != null)
                    hashCode = hashCode * 59 + this.OrderType.GetHashCode();
                if (this.TransactionType != null)
                    hashCode = hashCode * 59 + this.TransactionType.GetHashCode();
                if (this.DisclosedQuantity != null)
                    hashCode = hashCode * 59 + this.DisclosedQuantity.GetHashCode();
                if (this.TriggerPrice != null)
                    hashCode = hashCode * 59 + this.TriggerPrice.GetHashCode();
                if (this.IsAmo != null)
                    hashCode = hashCode * 59 + this.IsAmo.GetHashCode();
                if (this.CorrelationId != null)
                    hashCode = hashCode * 59 + this.CorrelationId.GetHashCode();
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
