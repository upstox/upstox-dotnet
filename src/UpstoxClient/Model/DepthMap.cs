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
    /// DepthMap
    /// </summary>
    [DataContract]
        public partial class DepthMap :  IEquatable<DepthMap>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepthMap" /> class.
        /// </summary>
        public DepthMap()
        {
        }
        
        /// <summary>
        /// Bids
        /// </summary>
        /// <value>Bids</value>
        [DataMember(Name="buy", EmitDefaultValue=false)]
        public List<Depth> Buy { get; private set; }

        /// <summary>
        /// Asks
        /// </summary>
        /// <value>Asks</value>
        [DataMember(Name="sell", EmitDefaultValue=false)]
        public List<Depth> Sell { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DepthMap {\n");
            sb.Append("  Buy: ").Append(Buy).Append("\n");
            sb.Append("  Sell: ").Append(Sell).Append("\n");
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
            return this.Equals(input as DepthMap);
        }

        /// <summary>
        /// Returns true if DepthMap instances are equal
        /// </summary>
        /// <param name="input">Instance of DepthMap to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DepthMap input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Buy == input.Buy ||
                    this.Buy != null &&
                    input.Buy != null &&
                    this.Buy.SequenceEqual(input.Buy)
                ) && 
                (
                    this.Sell == input.Sell ||
                    this.Sell != null &&
                    input.Sell != null &&
                    this.Sell.SequenceEqual(input.Sell)
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
                if (this.Buy != null)
                    hashCode = hashCode * 59 + this.Buy.GetHashCode();
                if (this.Sell != null)
                    hashCode = hashCode * 59 + this.Sell.GetHashCode();
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
