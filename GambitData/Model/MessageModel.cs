namespace GambitData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class MessageModel
    {

        [DataMember(Name = "client_salt")]
        public string ClientSalt { get; set; }

        [DataMember(Name = "access_key")]
        public string AccessKey { get; set; }

        [DataMember(Name = "namespace")]
        public string Namespace { get; set; }

        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        [DataMember(Name = "attributes")]
        public Dictionary<string, object> Attributes { get; set; }

        public void ValidateRequiredProparties()
        {
            if (string.IsNullOrEmpty(this.ClientSalt))
            {
                throw new ArgumentException("Proparty ClientSalt is required from MessageBody class");
            }

            if (string.IsNullOrEmpty(this.AccessKey))
            {
                throw new ArgumentException("Proparty AccessKey is required from MessageBody class");
            }

            if (string.IsNullOrEmpty(this.Namespace))
            {
                throw new ArgumentException("Proparty Namespace is required from MessageBody class");
            }
        }
    }
}
