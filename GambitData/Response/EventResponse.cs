namespace GambitData
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The EventResponse
    /// </summary>
    [DataContract]
    public class EventResponse : IEventResponseCode200
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
