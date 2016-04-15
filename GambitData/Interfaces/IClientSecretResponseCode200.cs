namespace GambitData
{
    public interface IClientSecretResponseCode200
    {
        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the client salt.
        /// </summary>
        string ClientSalt { get; set; }
    }
}
