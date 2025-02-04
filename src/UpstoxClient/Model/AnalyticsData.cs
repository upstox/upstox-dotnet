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
    /// AnalyticsData
    /// </summary>
    [DataContract]
        public partial class AnalyticsData :  IEquatable<AnalyticsData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyticsData" /> class.
        /// </summary>
        /// <param name="vega">vega.</param>
        /// <param name="theta">theta.</param>
        /// <param name="gamma">gamma.</param>
        /// <param name="delta">delta.</param>
        /// <param name="iv">iv.</param>
        /// <param name="pop">pop.</param>
        public AnalyticsData(double? vega = default(double?), double? theta = default(double?), double? gamma = default(double?), double? delta = default(double?), double? iv = default(double?), double? pop = default(double?))
        {
            this.Vega = vega;
            this.Theta = theta;
            this.Gamma = gamma;
            this.Delta = delta;
            this.Iv = iv;
            this.Pop = pop;
        }
        
        /// <summary>
        /// Gets or Sets Vega
        /// </summary>
        [DataMember(Name="vega", EmitDefaultValue=false)]
        public double? Vega { get; set; }

        /// <summary>
        /// Gets or Sets Theta
        /// </summary>
        [DataMember(Name="theta", EmitDefaultValue=false)]
        public double? Theta { get; set; }

        /// <summary>
        /// Gets or Sets Gamma
        /// </summary>
        [DataMember(Name="gamma", EmitDefaultValue=false)]
        public double? Gamma { get; set; }

        /// <summary>
        /// Gets or Sets Delta
        /// </summary>
        [DataMember(Name="delta", EmitDefaultValue=false)]
        public double? Delta { get; set; }

        /// <summary>
        /// Gets or Sets Iv
        /// </summary>
        [DataMember(Name="iv", EmitDefaultValue=false)]
        public double? Iv { get; set; }

        /// <summary>
        /// Gets or Sets Pop
        /// </summary>
        [DataMember(Name="pop", EmitDefaultValue=false)]
        public double? Pop { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AnalyticsData {\n");
            sb.Append("  Vega: ").Append(Vega).Append("\n");
            sb.Append("  Theta: ").Append(Theta).Append("\n");
            sb.Append("  Gamma: ").Append(Gamma).Append("\n");
            sb.Append("  Delta: ").Append(Delta).Append("\n");
            sb.Append("  Iv: ").Append(Iv).Append("\n");
            sb.Append("  Pop: ").Append(Pop).Append("\n");
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
            return this.Equals(input as AnalyticsData);
        }

        /// <summary>
        /// Returns true if AnalyticsData instances are equal
        /// </summary>
        /// <param name="input">Instance of AnalyticsData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AnalyticsData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Vega == input.Vega ||
                    (this.Vega != null &&
                    this.Vega.Equals(input.Vega))
                ) && 
                (
                    this.Theta == input.Theta ||
                    (this.Theta != null &&
                    this.Theta.Equals(input.Theta))
                ) && 
                (
                    this.Gamma == input.Gamma ||
                    (this.Gamma != null &&
                    this.Gamma.Equals(input.Gamma))
                ) && 
                (
                    this.Delta == input.Delta ||
                    (this.Delta != null &&
                    this.Delta.Equals(input.Delta))
                ) && 
                (
                    this.Iv == input.Iv ||
                    (this.Iv != null &&
                    this.Iv.Equals(input.Iv))
                ) && 
                (
                    this.Pop == input.Pop ||
                    (this.Pop != null &&
                    this.Pop.Equals(input.Pop))
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
                if (this.Vega != null)
                    hashCode = hashCode * 59 + this.Vega.GetHashCode();
                if (this.Theta != null)
                    hashCode = hashCode * 59 + this.Theta.GetHashCode();
                if (this.Gamma != null)
                    hashCode = hashCode * 59 + this.Gamma.GetHashCode();
                if (this.Delta != null)
                    hashCode = hashCode * 59 + this.Delta.GetHashCode();
                if (this.Iv != null)
                    hashCode = hashCode * 59 + this.Iv.GetHashCode();
                if (this.Pop != null)
                    hashCode = hashCode * 59 + this.Pop.GetHashCode();
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
