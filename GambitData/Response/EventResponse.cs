namespace GambitData
{
    using System.Runtime.Serialization;

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
