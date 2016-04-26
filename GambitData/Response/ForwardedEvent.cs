namespace Gambit.Data.Response
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The Forwarded Event contained in the <see cref="MessageResponse"/>
    /// </summary>
    public class ForwardedEvent
    {
        /// <summary>
        /// Gets or sets the Namespace
        /// </summary>
        [DataMember(Name = "namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the EventName
        /// </summary>
        [DataMember(Name = "event_name")]
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the Event Timestamp
        /// </summary>
        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the Event Attributes
        /// </summary>
        [DataMember(Name = "attributes")]
        public Dictionary<string, string> Attributes { get; set; }
    }
}
