namespace GambitData
{
    /// <summary>
    /// The Paths interface.
    /// </summary>
    public interface IPaths
    {
        /// <summary>
        /// Gets or sets the api docs object.
        /// </summary>
        IPathGet ApiDocsObject { get; set; }

        /// <summary>
        /// Gets or sets the client secret object.
        /// </summary>
        IPathPost ClientSecretObject { get; set; }

        /// <summary>
        /// Gets or sets the event object.
        /// </summary>
        IPathPost EventObject { get; set; }

        /// <summary>
        /// Gets or sets the random uuid object.
        /// </summary>
        IPathPost RandomUuidObject { get; set; }
    }
}
