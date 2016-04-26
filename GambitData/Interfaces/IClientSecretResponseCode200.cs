namespace GambitData
{
    /// <summary>
    /// Interface for marking the required members for ClientSecret OK response
    /// </summary>
    public interface IClientSecretResponseCode200
    {
        /// <summary>
        /// Gets or sets the client secret of the response
        /// </summary>
        string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the client salt of the response
        /// </summary>
        string ClientSalt { get; set; }
    }
}
