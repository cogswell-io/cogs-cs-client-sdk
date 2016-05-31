using System.Runtime.Serialization;

namespace Gambit.Data.Response
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Message response object used to deserialize incoming messages over web sockets
    /// </summary>
    [DataContract]
    public class MessageResponse
    {
        /// <summary>
        /// The Id for the received message
        /// </summary>
        [DataMember(Name = "message_id")]
        public string MessageId { get; set; }

        /// <summary>
        /// The Camaping Name for the received message
        /// </summary>
        [DataMember(Name = "campaign_name")]
        public string CampaignName { get; set; }

        /// <summary>
        /// The Namespace for the received message
        /// </summary>
        [DataMember(Name = "namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// The Event name for the received message
        /// </summary>
        [DataMember(Name = "event_name")]
        public string EventName { get; set; }

        /// <summary>
        /// The received message formatted as json object
        /// </summary>
        [JsonIgnore]
        public JObject JsonData { get; set; }
    }
}
