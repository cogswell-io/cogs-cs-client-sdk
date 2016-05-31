namespace GambitData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The event post body.
    /// </summary>
    [DataContract]
    public class EventModel : IEventModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventModel"/> class.
        /// </summary>
        public EventModel() : this(new Dictionary<string, object>(), new Dictionary<string, object>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventModel"/> class with dictionaries for the attributes collections
        /// </summary>
        /// <param name="attributes">Namespace attributes mapped to name and value dictionary</param>
        /// <param name="pkAttributes">Namespace attributes that are primary keys mapped to name and value dictionary</param>
        public EventModel(IDictionary<string, object> attributes, IDictionary<string, object> pkAttributes)
        {
            this.Attributes = attributes;
            this.PrimaryKeyAttributes = pkAttributes;
        }

        /// <summary>
        /// Optional collection of string tags
        /// </summary>
        [DataMember(Name = "tags", IsRequired = false, EmitDefaultValue = false)]
        public string[] Tags { get; set; }

        /// <summary>
        /// The Client Salt for the event
        /// </summary>
        [DataMember(Name = "client_salt")]
        public string ClientSalt { get; set; }

        /// <summary>
        /// The name of the event
        /// </summary>
        [DataMember(Name = "event_name")]
        public string EventName { get; set; }

        /// <summary>
        /// The access key for the event
        /// </summary>
        [DataMember(Name = "access_key")]
        public string AccessKey { get; set; }

        /// <summary>
        /// The Campaing Id for the event
        /// </summary>
        [DataMember(Name = "campaign_id", IsRequired = false, EmitDefaultValue = false)]
        public int CampaignId { get; set; }

        /// <summary>
        /// A dictionary that hold all the <see cref="NamespaceAttribute"/> attributes 
        /// mapped as <see cref="string"/> name and <see cref="object"/> value pairs
        /// </summary>
        [DataMember(Name = "attributes")]
        public IDictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// A dictionary that holds only the PrimaryKey attributes for quicker comparison
        /// </summary>
        public IDictionary<string, object> PrimaryKeyAttributes { get; set; }

        /// <summary>
        /// The namespace for the event
        /// </summary>
        [DataMember(Name = "namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// The timestamp for the event as <see cref="string"/>
        /// ISO-8601 <example>2016-01-15T11:54+0000</example>
        /// </summary>
        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// The optional debug directive for the event if any
        /// </summary>
        [DataMember(Name = "debug_directive", IsRequired = false, EmitDefaultValue = false)]
        public string DebugDirective { get; set; }

        /// <summary>
        /// An optional flag that is set to true if the event should be forwarded as message
        /// </summary>
        [DataMember(Name = "forward_as_message", IsRequired = false, EmitDefaultValue = false)]
        public bool ForwardAsMessage { get; set; }

        /// <summary>
        /// Validates the properties of the event.
        /// Used to assert that all required properties are set
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if there is a required property that isn't set or is an empty string
        /// </exception>
        public void ValidateRequiredProperties()
        {
            if (string.IsNullOrEmpty(this.ClientSalt))
            {
                throw new ArgumentException("Property ClientSalt is required from EventPostBody class");
            }

            if (string.IsNullOrEmpty(this.EventName))
            {
                throw new ArgumentException("Property EventName is required from EventPostBody class");
            }

            if (string.IsNullOrEmpty(this.AccessKey))
            {
                throw new ArgumentException("Property AccessKey is required from EventPostBody class");
            }

            if (string.IsNullOrEmpty(this.Namespace))
            {
                throw new ArgumentException("Property Namespace is required from EventPostBody class");
            }
        }

        /// <summary>
        /// Check if two Events have the same namespace and primary key attributes
        /// </summary>
        /// <param name="other">The event to compare equality to</param>
        /// <returns>True if they all of the above conditions match</returns>
        public bool Equals(IEventModel other)
        {
            bool areEqual =
                other != null &&
                other.Namespace.Equals(this.Namespace, StringComparison.Ordinal) &&
                other.PrimaryKeyAttributes.Count == this.PrimaryKeyAttributes.Count;

            if (areEqual)
            {
                foreach (var key in this.PrimaryKeyAttributes.Keys)
                {
                    if (!other.PrimaryKeyAttributes.ContainsKey(key) ||
                        !other.PrimaryKeyAttributes[key].Equals(this.PrimaryKeyAttributes[key]))
                    {
                        return false;
                    }
                }
            }

            return areEqual;
        }
    }
}
