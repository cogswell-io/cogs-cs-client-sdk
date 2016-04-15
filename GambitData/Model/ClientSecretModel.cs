namespace GambitData
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The client secret post body.
    /// </summary>
    [DataContract]
    public class ClientSecretModel : IClientSecretPostBody
    {
        [DataMember(Name = "access_key")]
        public string AccessKey { get; set; }

        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// The validate required proparties.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// </exception>
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
