namespace GambitData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The event post body.
    /// </summary>
    [DataContract]
    public class EventModel : IEventPostBody
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventModel"/> class.
        /// </summary>
        public EventModel()
        {
            //this.Attributes = EventAttributes.EventAttributesPlaceHolder;
        }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [DataMember(Name = "tags", IsRequired = false, EmitDefaultValue = false)]
        public string[] Tags { get; set; }

        /// <summary>
        /// Gets or sets the client salt.
        /// </summary>
        [DataMember(Name = "client_salt")]
        public string ClientSalt { get; set; }

        /// <summary>
        /// Gets or sets the event name.
        /// </summary>
        [DataMember(Name = "event_name")]
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the access key.
        /// </summary>
        [DataMember(Name = "access_key")]
        public string AccessKey { get; set; }

        /// <summary>
        /// Gets or sets the campaign id.
        /// </summary>
        [DataMember(Name = "campaign_id", IsRequired = false, EmitDefaultValue = false)]
        public int CampaignId { get; set; }

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        [DataMember(Name = "attributes")]
        public Dictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        [DataMember(Name = "namespace")]
        public string Namespace { get; set; }

        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        [DataMember(Name = "debug_directive", IsRequired = false, EmitDefaultValue = false)]
        public string DebugDirective { get; set; }

        [DataMember(Name = "forward_as_message", IsRequired = false, EmitDefaultValue = false)]
        public bool ForwardAsMessage { get; set; }

        /// <summary>
        /// The validate required proparties.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// </exception>
        public void ValidateRequiredProparties()
        {
            if (string.IsNullOrEmpty(this.ClientSalt))
            {
                throw new ArgumentException("Proparty ClientSalt is required from EventPostBody class");
            }

            if (string.IsNullOrEmpty(this.EventName))
            {
                throw new ArgumentException("Proparty EventName is required from EventPostBody class");
            }

            if (string.IsNullOrEmpty(this.AccessKey))
            {
                throw new ArgumentException("Proparty AccessKey is required from EventPostBody class");
            }

            if (string.IsNullOrEmpty(this.Namespace))
            {
                throw new ArgumentException("Proparty Namespace is required from EventPostBody class");
            }
        }

        /// <summary>
        /// Check if two Events have the same namespace and attributes
        /// </summary>
        /// <param name="obj">This should be an object of type <see cref="EventModel"/> or you will get false</param>
        /// <returns>True if they are equal</returns>
        public override bool Equals(object obj)
        {
            var other = obj as EventModel;

            bool areEqual =
                other != null &&
                other.Namespace.Equals(this.Namespace, StringComparison.Ordinal) &&
                other.Attributes.Count == this.Attributes.Count;

            if (areEqual)
            {
                foreach (var key in this.Attributes.Keys)
                {
                    if (other.Attributes.ContainsKey(key))
                    {
                        areEqual = this.Attributes[key].Equals(other.Attributes[key]);
                    }
                    else
                    {
                        areEqual = false;
                    }

                    if (!areEqual)
                    {
                        return false;
                    }
                }
            }

            return areEqual;
        }
    }
}
