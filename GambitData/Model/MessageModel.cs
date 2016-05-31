namespace GambitData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The message model
    /// </summary>
    [DataContract]
    public class MessageModel
    {
        /// <summary>
        /// The ClientSalt for the message
        /// </summary>
        [DataMember(Name = "client_salt")]
        public string ClientSalt { get; set; }

        /// <summary>
        /// The Message access key used for the the GambitSDK Service
        /// </summary>
        [DataMember(Name = "access_key")]
        public string AccessKey { get; set; }

        /// <summary>
        /// The namespace for the message
        /// </summary>
        [DataMember(Name = "namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// The timestamp for the event as <see cref="string"/>
        /// ISO-8601 <example>2016-01-15T11:54+0000</example>
        /// </summary>
        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// A dictionary that stores the Message attributes as a <see cref="string"/> key and <see cref="object"/> value pair
        /// </summary>
        [DataMember(Name = "attributes")]
        public Dictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Validates the properties of the message.
        /// Used to assert that all required properties are set
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if there is a required property that isn't set or is an empty string
        /// </exception>
        public void ValidateRequiredProparties()
        {
            if (string.IsNullOrEmpty(this.ClientSalt))
            {
                throw new ArgumentException("Property ClientSalt is required from MessageBody class");
            }

            if (string.IsNullOrEmpty(this.AccessKey))
            {
                throw new ArgumentException("Property AccessKey is required from MessageBody class");
            }

            if (string.IsNullOrEmpty(this.Namespace))
            {
                throw new ArgumentException("Property Namespace is required from MessageBody class");
            }
        }
    }
}
