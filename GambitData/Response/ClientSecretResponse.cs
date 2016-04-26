namespace GambitData
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Response to the ClientSecret request
    /// </summary>
    [DataContract]
    public class ClientSecretResponse : IClientSecretResponseCode200
    {
        /// <summary>
        /// Gets or sets the client secret of the response
        /// </summary>
        [DataMember(Name = "client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the client salt of the response
        /// </summary>
        [DataMember(Name = "client_salt")]
        public string ClientSalt { get; set; }
    }
}
