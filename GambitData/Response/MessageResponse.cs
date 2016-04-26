using System.Runtime.Serialization;

namespace Gambit.Data.Response
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The message response
    /// </summary>
    [DataContract]
    public class MessageResponse
    {
        /// <summary>
        /// Gets or sets the MessageId
        /// </summary>
        [DataMember(Name = "message_id")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the CampaignName
        /// </summary>
        [DataMember(Name = "campaign_name")]
        public string CampaignName { get; set; }

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
        /// Gets or sets the ForwardedEvent
        /// </summary>
        [DataMember(Name = "forwarded_event")]
        public ForwardedEvent ForwardedEvent { get; set; }

        /// <summary>
        /// The received message formatted as json object
        /// </summary>
        [JsonIgnore]
        public JObject JsonData { get; set; }
    }
}
