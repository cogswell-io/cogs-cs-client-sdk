namespace GambitData
{
    /// <summary>
    /// The ResponseErrorMessage interface.
    /// </summary>
    public interface IResponseErrorMessage
    {
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        string Details { get; set; }
    }
}
