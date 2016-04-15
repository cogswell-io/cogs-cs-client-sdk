namespace GambitData
{
    /// <summary>
    /// The RandomUuIdPostBody interface.
    /// </summary>
    public interface IRandomUuIdPostBody
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