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
    /// Response data for Balance
    /// </summary>
    [DataContract]
        public partial class UserFundMarginData :  IEquatable<UserFundMarginData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserFundMarginData" /> class.
        /// </summary>
        public UserFundMarginData()
        {
        }
        
        /// <summary>
        /// Positive values denote the amount blocked into an Open order or position.  Negative value denotes the amount being released.
        /// </summary>
        /// <value>Positive values denote the amount blocked into an Open order or position.  Negative value denotes the amount being released.</value>
        [DataMember(Name="used_margin", EmitDefaultValue=false)]
        public float? UsedMargin { get; private set; }

        /// <summary>
        /// Instant payin will reflect here
        /// </summary>
        /// <value>Instant payin will reflect here</value>
        [DataMember(Name="payin_amount", EmitDefaultValue=false)]
        public float? PayinAmount { get; private set; }

        /// <summary>
        /// Amount blocked on futures and options towards SPAN
        /// </summary>
        /// <value>Amount blocked on futures and options towards SPAN</value>
        [DataMember(Name="span_margin", EmitDefaultValue=false)]
        public float? SpanMargin { get; private set; }

        /// <summary>
        /// Payin amount credited through a manual process
        /// </summary>
        /// <value>Payin amount credited through a manual process</value>
        [DataMember(Name="adhoc_margin", EmitDefaultValue=false)]
        public float? AdhocMargin { get; private set; }

        /// <summary>
        /// The amount maintained for withdrawal
        /// </summary>
        /// <value>The amount maintained for withdrawal</value>
        [DataMember(Name="notional_cash", EmitDefaultValue=false)]
        public float? NotionalCash { get; private set; }

        /// <summary>
        /// Total margin available for trading
        /// </summary>
        /// <value>Total margin available for trading</value>
        [DataMember(Name="available_margin", EmitDefaultValue=false)]
        public float? AvailableMargin { get; private set; }

        /// <summary>
        /// Amount blocked on futures and options towards Exposure
        /// </summary>
        /// <value>Amount blocked on futures and options towards Exposure</value>
        [DataMember(Name="exposure_margin", EmitDefaultValue=false)]
        public float? ExposureMargin { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserFundMarginData {\n");
            sb.Append("  UsedMargin: ").Append(UsedMargin).Append("\n");
            sb.Append("  PayinAmount: ").Append(PayinAmount).Append("\n");
            sb.Append("  SpanMargin: ").Append(SpanMargin).Append("\n");
            sb.Append("  AdhocMargin: ").Append(AdhocMargin).Append("\n");
            sb.Append("  NotionalCash: ").Append(NotionalCash).Append("\n");
            sb.Append("  AvailableMargin: ").Append(AvailableMargin).Append("\n");
            sb.Append("  ExposureMargin: ").Append(ExposureMargin).Append("\n");
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
            return this.Equals(input as UserFundMarginData);
        }

        /// <summary>
        /// Returns true if UserFundMarginData instances are equal
        /// </summary>
        /// <param name="input">Instance of UserFundMarginData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserFundMarginData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.UsedMargin == input.UsedMargin ||
                    (this.UsedMargin != null &&
                    this.UsedMargin.Equals(input.UsedMargin))
                ) && 
                (
                    this.PayinAmount == input.PayinAmount ||
                    (this.PayinAmount != null &&
                    this.PayinAmount.Equals(input.PayinAmount))
                ) && 
                (
                    this.SpanMargin == input.SpanMargin ||
                    (this.SpanMargin != null &&
                    this.SpanMargin.Equals(input.SpanMargin))
                ) && 
                (
                    this.AdhocMargin == input.AdhocMargin ||
                    (this.AdhocMargin != null &&
                    this.AdhocMargin.Equals(input.AdhocMargin))
                ) && 
                (
                    this.NotionalCash == input.NotionalCash ||
                    (this.NotionalCash != null &&
                    this.NotionalCash.Equals(input.NotionalCash))
                ) && 
                (
                    this.AvailableMargin == input.AvailableMargin ||
                    (this.AvailableMargin != null &&
                    this.AvailableMargin.Equals(input.AvailableMargin))
                ) && 
                (
                    this.ExposureMargin == input.ExposureMargin ||
                    (this.ExposureMargin != null &&
                    this.ExposureMargin.Equals(input.ExposureMargin))
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
                if (this.UsedMargin != null)
                    hashCode = hashCode * 59 + this.UsedMargin.GetHashCode();
                if (this.PayinAmount != null)
                    hashCode = hashCode * 59 + this.PayinAmount.GetHashCode();
                if (this.SpanMargin != null)
                    hashCode = hashCode * 59 + this.SpanMargin.GetHashCode();
                if (this.AdhocMargin != null)
                    hashCode = hashCode * 59 + this.AdhocMargin.GetHashCode();
                if (this.NotionalCash != null)
                    hashCode = hashCode * 59 + this.NotionalCash.GetHashCode();
                if (this.AvailableMargin != null)
                    hashCode = hashCode * 59 + this.AvailableMargin.GetHashCode();
                if (this.ExposureMargin != null)
                    hashCode = hashCode * 59 + this.ExposureMargin.GetHashCode();
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
