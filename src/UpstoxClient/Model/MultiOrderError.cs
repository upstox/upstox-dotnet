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
    /// Error details for multi order request
    /// </summary>
    [DataContract]
        public partial class MultiOrderError :  IEquatable<MultiOrderError>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiOrderError" /> class.
        /// </summary>
        /// <param name="errorCode">Unique code for the error state.</param>
        /// <param name="message">Verbose message for the error state.</param>
        /// <param name="propertyPath">Path to property failing validation.</param>
        /// <param name="invalidValue">Invalid value for the property failing validation.</param>
        /// <param name="errorCode">errorCode.</param>
        /// <param name="propertyPath">propertyPath.</param>
        /// <param name="invalidValue">invalidValue.</param>
        public MultiOrderError(string errorCode = default(string), string message = default(string), string propertyPath = default(string), Object invalidValue = default(Object))
        {
            this.ErrorCode = errorCode;
            this.Message = message;
            this.PropertyPath = propertyPath;
            this.InvalidValue = invalidValue;
        }
        
        /// <summary>
        /// Unique code for the error state
        /// </summary>
        /// <value>Unique code for the error state</value>
        [DataMember(Name="errorCode", EmitDefaultValue=false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Verbose message for the error state
        /// </summary>
        /// <value>Verbose message for the error state</value>
        [DataMember(Name="message", EmitDefaultValue=false)]
        public string Message { get; set; }

        /// <summary>
        /// Path to property failing validation
        /// </summary>
        /// <value>Path to property failing validation</value>
        [DataMember(Name="propertyPath", EmitDefaultValue=false)]
        public string PropertyPath { get; set; }

        /// <summary>
        /// Invalid value for the property failing validation
        /// </summary>
        /// <value>Invalid value for the property failing validation</value>
        [DataMember(Name="invalidValue", EmitDefaultValue=false)]
        public Object InvalidValue { get; set; }

        /// <summary>
        /// A unique identifier for tracking individual orders within the batch
        /// </summary>
        /// <value>A unique identifier for tracking individual orders within the batch</value>
        [DataMember(Name="correlation_id", EmitDefaultValue=false)]
        public string CorrelationId { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MultiOrderError {\n");
            sb.Append("  ErrorCode: ").Append(ErrorCode).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  PropertyPath: ").Append(PropertyPath).Append("\n");
            sb.Append("  InvalidValue: ").Append(InvalidValue).Append("\n");
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
            return this.Equals(input as MultiOrderError);
        }

        /// <summary>
        /// Returns true if MultiOrderError instances are equal
        /// </summary>
        /// <param name="input">Instance of MultiOrderError to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MultiOrderError input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ErrorCode == input.ErrorCode ||
                    (this.ErrorCode != null &&
                    this.ErrorCode.Equals(input.ErrorCode))
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.PropertyPath == input.PropertyPath ||
                    (this.PropertyPath != null &&
                    this.PropertyPath.Equals(input.PropertyPath))
                ) && 
                (
                    this.InvalidValue == input.InvalidValue ||
                    (this.InvalidValue != null &&
                    this.InvalidValue.Equals(input.InvalidValue))
                ) && 
                (
                    this.ErrorCode == input.ErrorCode ||
                    (this.ErrorCode != null &&
                    this.ErrorCode.Equals(input.ErrorCode))
                ) && 
                (
                    this.PropertyPath == input.PropertyPath ||
                    (this.PropertyPath != null &&
                    this.PropertyPath.Equals(input.PropertyPath))
                ) && 
                (
                    this.InvalidValue == input.InvalidValue ||
                    (this.InvalidValue != null &&
                    this.InvalidValue.Equals(input.InvalidValue))
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
                if (this.ErrorCode != null)
                    hashCode = hashCode * 59 + this.ErrorCode.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.PropertyPath != null)
                    hashCode = hashCode * 59 + this.PropertyPath.GetHashCode();
                if (this.InvalidValue != null)
                    hashCode = hashCode * 59 + this.InvalidValue.GetHashCode();
                if (this.ErrorCode != null)
                    hashCode = hashCode * 59 + this.ErrorCode.GetHashCode();
                if (this.PropertyPath != null)
                    hashCode = hashCode * 59 + this.PropertyPath.GetHashCode();
                if (this.InvalidValue != null)
                    hashCode = hashCode * 59 + this.InvalidValue.GetHashCode();
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
