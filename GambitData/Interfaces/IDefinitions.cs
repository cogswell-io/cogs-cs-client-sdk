namespace GambitData
{
    /// <summary>
    /// The Definitions interface.
    /// </summary>
    public interface IDefinitions
    {
        /// <summary>
        /// Gets or sets the client secret response object.
        /// </summary>
        IAviataApiModel ClientSecretResponseObject { get; set; }

        /// <summary>
        /// Gets or sets the error message object.
        /// </summary>
        IAviataApiModel ErrorMessageObject { get; set; }

        /// <summary>
        /// Gets or sets the message result body object.
        /// </summary>
        IAviataApiModel MessageResultBodyObject { get; set; }

        /// <summary>
        /// Gets or sets the event object.
        /// </summary>
        IAviataApiModel EventObject { get; set; }

        /// <summary>
        /// Gets or sets the uuid response object.
        /// </summary>
        IAviataApiModel UuidResponseObject { get; set; }

        /// <summary>
        /// Gets or sets the data generation request object.
        /// </summary>
        IAviataApiModel DataGenerationRequestObject { get; set; }
    }
}
