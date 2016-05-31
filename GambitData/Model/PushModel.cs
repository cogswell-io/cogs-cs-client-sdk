namespace GambitData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The PushModel used for web socket push messages
    /// </summary>
    [DataContract]
    public class PushModel
    {
        /// <summary>
        /// The namespace for the message
        /// </summary>
        [DataMember(Name = "namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// The ClientSalt for the message
        /// </summary>
        [DataMember(Name = "client_salt")]
        public string ClientSalt { get; set; }

        /// <summary>
        /// The AccessKey for the message
        /// </summary>
        [DataMember(Name = "access_key")]
        public string AccessKey { get; set; }

        /// <summary>
        /// The timestamp for the event as <see cref="string"/>
        /// ISO-8601 <example>2016-01-15T11:54+0000</example>
        /// </summary>
        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// A dictionary that hold the message attributes as a <see cref="string"/> key and <see cref="object"/> value pair
        /// </summary>
        [DataMember(Name = "attributes")]
        public Dictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Validates the properties of the push message.
        /// Used to assert that all required properties are set
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if there is a required property that isn't set or is an empty string
        /// </exception>
        public void ValidateRequiredProparties()
        {
            if (string.IsNullOrEmpty(this.ClientSalt))
            {
                throw new ArgumentException("Proparty ClientSalt is required from PushModel class");
            }

            if (string.IsNullOrEmpty(this.AccessKey))
            {
                throw new ArgumentException("Proparty AccessKey is required from PushModel class");
            }

            if (string.IsNullOrEmpty(this.Namespace))
            {
                throw new ArgumentException("Proparty Namespace is required from PushModel class");
            }
        }
    }
}
