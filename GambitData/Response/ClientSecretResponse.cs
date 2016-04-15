namespace GambitData
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The client secret response code 200.
    /// </summary>
    [DataContract]
    public class ClientSecretResponse : IClientSecretResponseCode200
    {
        [DataMember(Name = "client_secret")]
        public string ClientSecret { get; set; }

        [DataMember(Name = "client_salt")]
        public string ClientSalt { get; set; }

    }
}
