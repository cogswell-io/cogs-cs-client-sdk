namespace GambitData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The PushModel
    /// </summary>
    [DataContract]
    public class PushModel
    {
        /// <summary>
        /// Gets or sets the Namespace
        /// </summary>
        [DataMember(Name = "namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the ClientSalt
        /// </summary>
        [DataMember(Name = "client_salt")]
        public string ClientSalt { get; set; }

        /// <summary>
        /// Gets or sets the AccessKey
        /// </summary
        [DataMember(Name = "access_key")]
        public string AccessKey { get; set; }

        /// <summary>
        /// Gets or sets the AccessKey
        /// </summary>
        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the Attributes
        /// </summary>
        [DataMember(Name = "attributes")]
        public Dictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Validates the required properties and throws an exception if some of the fields is not entered
        /// </summary>
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
