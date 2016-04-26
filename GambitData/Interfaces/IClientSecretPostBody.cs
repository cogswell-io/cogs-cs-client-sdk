namespace GambitData
{
    /// <summary>
    /// Interface for marking the base set of required members for a body of ClientSecret request
    /// </summary>
    public interface IClientSecretPostBody
    {
        /// <summary>
        /// Gets or sets the access key for the request
        /// </summary>
        string AccessKey { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the request
        /// </summary>
        string Timestamp { get; set; }

        /// <summary>
        /// Validates the required properties
        /// </summary>
        void ValidateRequiredProparties();
    }
}