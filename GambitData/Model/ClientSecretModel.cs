namespace GambitData
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// A model for the body of the ClientSecret request
    /// </summary>
    [DataContract]
    public class ClientSecretModel : IClientSecretPostBody
    {
        /// <summary>
        /// Gets or sets the access key for the request
        /// </summary>
        [DataMember(Name = "access_key")]
        public string AccessKey { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the request
        /// </summary>
        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// Validates the required properties
        /// </summary>
        public void ValidateRequiredProparties()
        {
            if (string.IsNullOrEmpty(this.AccessKey))
            {
                throw new ArgumentException("Proparty AccessKey is required from ClientSecretPostBody class");
            }

            if (string.IsNullOrEmpty(this.Timestamp))
            {
                throw new ArgumentException("Proparty Timestamp is required from ClientSecretPostBody class");
            }
        }
    }
}
