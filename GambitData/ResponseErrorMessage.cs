namespace GambitData
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The ResponseErrorMessage
    /// </summary>
    [DataContract]
    public class ResponseErrorMessage : IResponseErrorMessage
    {
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        [DataMember(Name = "error_message")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        [DataMember(Name = "details")]
        public string Details { get; set; }
    }
}
