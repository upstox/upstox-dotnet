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
    /// Response data for user profile
    /// </summary>
    [DataContract]
        public partial class ProfileData :  IEquatable<ProfileData>, IValidatableObject
    {
        /// <summary>
        /// Lists the exchanges to which the user has access
        /// </summary>
        /// <value>Lists the exchanges to which the user has access</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum ExchangesEnum
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
        /// Lists the exchanges to which the user has access
        /// </summary>
        /// <value>Lists the exchanges to which the user has access</value>
        [DataMember(Name="exchanges", EmitDefaultValue=false)]
        public List<ExchangesEnum> Exchanges { get; set; }
        /// <summary>
        /// Lists the products types to which the user has access
        /// </summary>
        /// <value>Lists the products types to which the user has access</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum ProductsEnum
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
            D = 2,
            /// <summary>
            /// Enum CO for value: CO
            /// </summary>
            [EnumMember(Value = "CO")]
            CO = 3,
            /// <summary>
            /// Enum OCO for value: OCO
            /// </summary>
            [EnumMember(Value = "OCO")]
            OCO = 4,
            /// <summary>
            /// Enum MTF for value: MTF
            /// </summary>
            [EnumMember(Value = "MTF")]
            MTF = 5        }
        /// <summary>
        /// Lists the products types to which the user has access
        /// </summary>
        /// <value>Lists the products types to which the user has access</value>
        [DataMember(Name="products", EmitDefaultValue=false)]
        public List<ProductsEnum> Products { get; set; }
        /// <summary>
        /// Order types enabled for the user
        /// </summary>
        /// <value>Order types enabled for the user</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum OrderTypesEnum
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
        /// Order types enabled for the user
        /// </summary>
        /// <value>Order types enabled for the user</value>
        [DataMember(Name="order_types", EmitDefaultValue=false)]
        public List<OrderTypesEnum> OrderTypes { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileData" /> class.
        /// </summary>
        public ProfileData()
        {
        }
        
        /// <summary>
        /// E-mail address of the user
        /// </summary>
        /// <value>E-mail address of the user</value>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; private set; }



        /// <summary>
        /// The broker ID
        /// </summary>
        /// <value>The broker ID</value>
        [DataMember(Name="broker", EmitDefaultValue=false)]
        public string Broker { get; private set; }

        /// <summary>
        /// Uniquely identifies the user
        /// </summary>
        /// <value>Uniquely identifies the user</value>
        [DataMember(Name="user_id", EmitDefaultValue=false)]
        public string UserId { get; private set; }

        /// <summary>
        /// Name of the user
        /// </summary>
        /// <value>Name of the user</value>
        [DataMember(Name="user_name", EmitDefaultValue=false)]
        public string UserName { get; private set; }


        /// <summary>
        ///   Identifies the user&#x27;s registered role at the broker. This will be individual for all retail users
        /// </summary>
        /// <value>  Identifies the user&#x27;s registered role at the broker. This will be individual for all retail users</value>
        [DataMember(Name="user_type", EmitDefaultValue=false)]
        public string UserType { get; private set; }

        /// <summary>
        ///   To depict if the user has given power of attorney for transactions
        /// </summary>
        /// <value>  To depict if the user has given power of attorney for transactions</value>
        [DataMember(Name="poa", EmitDefaultValue=false)]
        public bool? Poa { get; private set; }

        /// <summary>
        ///   Whether the status of account is active or not
        /// </summary>
        /// <value>  Whether the status of account is active or not</value>
        [DataMember(Name="is_active", EmitDefaultValue=false)]
        public bool? IsActive { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProfileData {\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Exchanges: ").Append(Exchanges).Append("\n");
            sb.Append("  Products: ").Append(Products).Append("\n");
            sb.Append("  Broker: ").Append(Broker).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  UserName: ").Append(UserName).Append("\n");
            sb.Append("  OrderTypes: ").Append(OrderTypes).Append("\n");
            sb.Append("  UserType: ").Append(UserType).Append("\n");
            sb.Append("  Poa: ").Append(Poa).Append("\n");
            sb.Append("  IsActive: ").Append(IsActive).Append("\n");
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
            return this.Equals(input as ProfileData);
        }

        /// <summary>
        /// Returns true if ProfileData instances are equal
        /// </summary>
        /// <param name="input">Instance of ProfileData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProfileData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.Exchanges == input.Exchanges ||
                    this.Exchanges != null &&
                    input.Exchanges != null &&
                    this.Exchanges.SequenceEqual(input.Exchanges)
                ) && 
                (
                    this.Products == input.Products ||
                    this.Products != null &&
                    input.Products != null &&
                    this.Products.SequenceEqual(input.Products)
                ) && 
                (
                    this.Broker == input.Broker ||
                    (this.Broker != null &&
                    this.Broker.Equals(input.Broker))
                ) && 
                (
                    this.UserId == input.UserId ||
                    (this.UserId != null &&
                    this.UserId.Equals(input.UserId))
                ) && 
                (
                    this.UserName == input.UserName ||
                    (this.UserName != null &&
                    this.UserName.Equals(input.UserName))
                ) && 
                (
                    this.OrderTypes == input.OrderTypes ||
                    this.OrderTypes != null &&
                    input.OrderTypes != null &&
                    this.OrderTypes.SequenceEqual(input.OrderTypes)
                ) && 
                (
                    this.UserType == input.UserType ||
                    (this.UserType != null &&
                    this.UserType.Equals(input.UserType))
                ) && 
                (
                    this.Poa == input.Poa ||
                    (this.Poa != null &&
                    this.Poa.Equals(input.Poa))
                ) && 
                (
                    this.IsActive == input.IsActive ||
                    (this.IsActive != null &&
                    this.IsActive.Equals(input.IsActive))
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
                if (this.Email != null)
                    hashCode = hashCode * 59 + this.Email.GetHashCode();
                if (this.Exchanges != null)
                    hashCode = hashCode * 59 + this.Exchanges.GetHashCode();
                if (this.Products != null)
                    hashCode = hashCode * 59 + this.Products.GetHashCode();
                if (this.Broker != null)
                    hashCode = hashCode * 59 + this.Broker.GetHashCode();
                if (this.UserId != null)
                    hashCode = hashCode * 59 + this.UserId.GetHashCode();
                if (this.UserName != null)
                    hashCode = hashCode * 59 + this.UserName.GetHashCode();
                if (this.OrderTypes != null)
                    hashCode = hashCode * 59 + this.OrderTypes.GetHashCode();
                if (this.UserType != null)
                    hashCode = hashCode * 59 + this.UserType.GetHashCode();
                if (this.Poa != null)
                    hashCode = hashCode * 59 + this.Poa.GetHashCode();
                if (this.IsActive != null)
                    hashCode = hashCode * 59 + this.IsActive.GetHashCode();
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
