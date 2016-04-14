using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IO.Swagger.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Synthesis :  IEquatable<Synthesis>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="Synthesis" /> class.
        /// Initializes a new instance of the <see cref="Synthesis" />class.
        /// </summary>
        /// <param name="SensorType">Type de capteur \u00E0 l&#39;origine de l&#39;emission du message..</param>
        /// <param name="MinValue">Valeur minimum transmise par ce type de capteur..</param>
        /// <param name="MaxValue">Valeur maximale transmise par ce capteur type de capteur..</param>
        /// <param name="MediumValue">Valeur moyenne des donn\u00E9es transmises par ce type de capteur..</param>

        public Synthesis(int? SensorType = null, long? MinValue = null, long? MaxValue = null, long? MediumValue = null)
        {
            this.SensorType = SensorType;
            this.MinValue = MinValue;
            this.MaxValue = MaxValue;
            this.MediumValue = MediumValue;
            
        }

    
        /// <summary>
        /// Type de capteur \u00E0 l&#39;origine de l&#39;emission du message.
        /// </summary>
        /// <value>Type de capteur \u00E0 l&#39;origine de l&#39;emission du message.</value>
        [DataMember(Name="sensorType", EmitDefaultValue=false)]
        public int? SensorType { get; set; }
    
        /// <summary>
        /// Valeur minimum transmise par ce type de capteur.
        /// </summary>
        /// <value>Valeur minimum transmise par ce type de capteur.</value>
        [DataMember(Name="minValue", EmitDefaultValue=false)]
        public long? MinValue { get; set; }
    
        /// <summary>
        /// Valeur maximale transmise par ce capteur type de capteur.
        /// </summary>
        /// <value>Valeur maximale transmise par ce capteur type de capteur.</value>
        [DataMember(Name="maxValue", EmitDefaultValue=false)]
        public long? MaxValue { get; set; }
    
        /// <summary>
        /// Valeur moyenne des donn\u00E9es transmises par ce type de capteur.
        /// </summary>
        /// <value>Valeur moyenne des donn\u00E9es transmises par ce type de capteur.</value>
        [DataMember(Name="mediumValue", EmitDefaultValue=false)]
        public long? MediumValue { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Synthesis {\n");
            sb.Append("  SensorType: ").Append(SensorType).Append("\n");
            sb.Append("  MinValue: ").Append(MinValue).Append("\n");
            sb.Append("  MaxValue: ").Append(MaxValue).Append("\n");
            sb.Append("  MediumValue: ").Append(MediumValue).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as Synthesis);
        }

        /// <summary>
        /// Returns true if Synthesis instances are equal
        /// </summary>
        /// <param name="other">Instance of Synthesis to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Synthesis other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.SensorType == other.SensorType ||
                    this.SensorType != null &&
                    this.SensorType.Equals(other.SensorType)
                ) && 
                (
                    this.MinValue == other.MinValue ||
                    this.MinValue != null &&
                    this.MinValue.Equals(other.MinValue)
                ) && 
                (
                    this.MaxValue == other.MaxValue ||
                    this.MaxValue != null &&
                    this.MaxValue.Equals(other.MaxValue)
                ) && 
                (
                    this.MediumValue == other.MediumValue ||
                    this.MediumValue != null &&
                    this.MediumValue.Equals(other.MediumValue)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.SensorType != null)
                    hash = hash * 59 + this.SensorType.GetHashCode();
                if (this.MinValue != null)
                    hash = hash * 59 + this.MinValue.GetHashCode();
                if (this.MaxValue != null)
                    hash = hash * 59 + this.MaxValue.GetHashCode();
                if (this.MediumValue != null)
                    hash = hash * 59 + this.MediumValue.GetHashCode();
                return hash;
            }
        }

    }
}
