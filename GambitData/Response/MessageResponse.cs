using System.Runtime.Serialization;

namespace Gambit.Data.Response
{
    [DataContract]
    public class MessageResponse
    {
        [DataMember(Name = "message_id")]
        public string MessageId { get; set; }

        [DataMember(Name = "ciid_hash")]
        public string CiidHash { get; set; }

        [DataMember(Name = "campaign_id")]
        public string CampaignId { get; set; }

        [DataMember(Name = "campaign_name")]
        public string CampaignName { get; set; }

        [DataMember(Name = "namespace")]
        public string Namespace { get; set; }

        [DataMember(Name = "event_name")]
        public string EventName { get; set; }

        [DataMember(Name = "data")]
        public string Data { get; set; }

        [DataMember(Name = "forwarded_event")]
        public string ForwardedEvent { get; set; }

    }
}
