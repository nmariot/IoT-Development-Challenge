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
    public partial class Message :  IEquatable<Message>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="Message" /> class.
        /// Initializes a new instance of the <see cref="Message" />class.
        /// </summary>
        /// <param name="Id">Identifiant unique du message envoy\u00E9 par le capteur, un controle des doublons doit \u00EAtre effectu\u00E9 (max 64 chars)..</param>
        /// <param name="Timestamp">Horaire de la fabrication du message par le capteur (format RFC3339, exemple:1985-0412T23:20:50.52Z). Ce timestamp fait fois lors calcul de la synth\u00E8se..</param>
        /// <param name="SensorType">Type de capteur \u00E0 l&#39;origine de l&#39;emission du message..</param>
        /// <param name="Value">Valeur transmise par le capteur..</param>

        public Message(string Id = null, DateTime? Timestamp = null, int? SensorType = null, long? Value = null)
        {
            this.Id = Id;
            this.Timestamp = Timestamp;
            this.SensorType = SensorType;
            this.Value = Value;
            
        }

    
        /// <summary>
        /// Identifiant unique du message envoy\u00E9 par le capteur, un controle des doublons doit \u00EAtre effectu\u00E9 (max 64 chars).
        /// </summary>
        /// <value>Identifiant unique du message envoy\u00E9 par le capteur, un controle des doublons doit \u00EAtre effectu\u00E9 (max 64 chars).</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
    
        /// <summary>
        /// Horaire de la fabrication du message par le capteur (format RFC3339, exemple:1985-0412T23:20:50.52Z). Ce timestamp fait fois lors calcul de la synth\u00E8se.
        /// </summary>
        /// <value>Horaire de la fabrication du message par le capteur (format RFC3339, exemple:1985-0412T23:20:50.52Z). Ce timestamp fait fois lors calcul de la synth\u00E8se.</value>
        [DataMember(Name="timestamp", EmitDefaultValue=false)]
        public DateTime? Timestamp { get; set; }
    
        /// <summary>
        /// Type de capteur \u00E0 l&#39;origine de l&#39;emission du message.
        /// </summary>
        /// <value>Type de capteur \u00E0 l&#39;origine de l&#39;emission du message.</value>
        [DataMember(Name="sensorType", EmitDefaultValue=false)]
        public int? SensorType { get; set; }
    
        /// <summary>
        /// Valeur transmise par le capteur.
        /// </summary>
        /// <value>Valeur transmise par le capteur.</value>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public long? Value { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Message {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  SensorType: ").Append(SensorType).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return this.Equals(obj as Message);
        }

        /// <summary>
        /// Returns true if Message instances are equal
        /// </summary>
        /// <param name="other">Instance of Message to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Message other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Timestamp == other.Timestamp ||
                    this.Timestamp != null &&
                    this.Timestamp.Equals(other.Timestamp)
                ) && 
                (
                    this.SensorType == other.SensorType ||
                    this.SensorType != null &&
                    this.SensorType.Equals(other.SensorType)
                ) && 
                (
                    this.Value == other.Value ||
                    this.Value != null &&
                    this.Value.Equals(other.Value)
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
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.Timestamp != null)
                    hash = hash * 59 + this.Timestamp.GetHashCode();
                if (this.SensorType != null)
                    hash = hash * 59 + this.SensorType.GetHashCode();
                if (this.Value != null)
                    hash = hash * 59 + this.Value.GetHashCode();
                return hash;
            }
        }

    }
}
