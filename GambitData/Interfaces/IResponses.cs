namespace GambitData
{
    /// <summary>
    /// The Responses interface.
    /// </summary>
    public interface IResponses
    {
        /// <summary>
        /// Gets or sets the code 200 object.
        /// </summary>
        IResponseCodeBody Code200Object { get; set; }

        /// <summary>
        /// Gets or sets the code 400 object.
        /// </summary>
        IResponseCodeBody Code400Object { get; set; }

        /// <summary>
        /// Gets or sets the code 401 object.
        /// </summary>
        IResponseCodeBody Code401Object { get; set; }

        /// <summary>
        /// Gets or sets the code 418 object.
        /// </summary>
        IResponseCodeBody Code418Object { get; set; }

        /// <summary>
        /// Gets or sets the code 500 object.
        /// </summary>
        IResponseCodeBody Code500Object { get; set; }
    }
}
