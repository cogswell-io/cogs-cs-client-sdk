namespace GambitData
{
    using System.Runtime.Serialization;

    /// <summary>
    /// EventResponse object used for the http event responses in the GabitSDK Service
    /// </summary>
    [DataContract]
    public class EventResponse
    {
        /// <summary>
        /// The response's message
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
