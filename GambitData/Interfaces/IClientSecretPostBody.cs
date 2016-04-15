namespace GambitData
{
    /// <summary>
    /// The ClientSecretPostBody interface.
    /// </summary>
    public interface IClientSecretPostBody
    {
        /// <summary>
        /// Gets or sets the access key.
        /// </summary>
        string AccessKey { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        string Timestamp { get; set; }

        /// <summary>
        /// The validate required proparties.
        /// </summary>
        void ValidateRequiredProparties();
    }
}