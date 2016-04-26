namespace GambitData
{
    using System;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;

    /// <summary>
    /// The properties.
    /// </summary>
    [Serializable]
    [DataContract(Name = "Properties")]
    [Export(typeof(IProperties))]
    public class Properties : IProperties
    {
        /// <summary>
        /// Constructor for initializing the class
        /// </summary>
        public Properties()
        {
            MyClientSecret = new PropertieBody();
            MyClientSalt = new PropertieBody();
            MyErrorMessage = new PropertieBody();
            MyMessage = new PropertieBody();
            MyDetails = new PropertieBody();
            MyEventName = new PropertieBody();
            MyAccessKey = new PropertieBody();
            MyAttributes = new PropertieBody();
            MyCampaignId = new PropertieBody();
            MyNamespace = new PropertieBody();
            MyUuId = new PropertieBody();
            MyTimeStamp = new PropertieBody();
            MyTags = new PropertieBody();
        }

        [DataMember(Name = "client_secret")]
        PropertieBody MyClientSecret { get; set; }

        [DataMember(Name = "client_salt")]
        PropertieBody MyClientSalt { get; set; }

        [DataMember(Name = "error_message")]
        PropertieBody MyErrorMessage { get; set; }

        [DataMember(Name = "message")]
        PropertieBody MyMessage { get; set; }

        [DataMember(Name = "details")]
        PropertieBody MyDetails { get; set; }

        [DataMember(Name = "event_name")]
        PropertieBody MyEventName { get; set; }

        [DataMember(Name = "access_key")]
        PropertieBody MyAccessKey { get; set; }

        [DataMember(Name = "attributes")]
        PropertieBody MyAttributes { get; set; }

        [DataMember(Name = "campaign_id")]
        PropertieBody MyCampaignId { get; set; }

        [DataMember(Name = "namespace")]
        PropertieBody MyNamespace { get; set; }

        [DataMember(Name = "uuid")]
        PropertieBody MyUuId { get; set; }

        [DataMember(Name = "timestamp")]
        PropertieBody MyTimeStamp { get; set; }

        [DataMember(Name = "tags")]
        PropertieBody MyTags { get; set; }

        /// <summary>
        /// Gets or sets the client secret object.
        /// </summary>
        [IgnoreDataMember]
        public IPropertieBody ClientSecretObject
        {
            get
            {
                return MyClientSecret;
            }

            set
            {
                MyClientSecret = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the client salt object.
        /// </summary>
        [IgnoreDataMember]
        public IPropertieBody ClientSaltObject
        {
            get
            {
                return MyClientSalt;
            }

            set
            {
                MyClientSalt = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the error message object.
        /// </summary>
        [IgnoreDataMember]
        public IPropertieBody ErrorMessageObject
        {
            get
            {
                return MyErrorMessage;
            }

            set
            {
                MyErrorMessage = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the message object.
        /// </summary>
        [IgnoreDataMember]
        public IPropertieBody MessageObject
        {
            get
            {
                return MyMessage;
            }

            set
            {
                MyMessage = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the details object.
        /// </summary>
        [IgnoreDataMember]
        public IPropertieBody DetailsObject
        {
            get
            {
                return MyDetails;
            }

            set
            {
                MyDetails = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the event name object.
        /// </summary>
        [IgnoreDataMember]
        public IPropertieBody EventNameObject
        {
            get
            {
                return MyEventName;
            }

            set
            {
                MyEventName = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the access key object.
        /// </summary>
        [IgnoreDataMember]
        public IPropertieBody AccessKeyObject
        {
            get
            {
                return MyAccessKey;
            }

            set
            {
                MyAccessKey = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the attributes object.
        /// </summary>
        [IgnoreDataMember]
        public IPropertieBody AttributesObject
        {
            get
            {
                return MyAttributes;
            }

            set
            {
                MyAttributes = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the campaign id object.
        /// </summary>
        [IgnoreDataMember]
        public IPropertieBody CampaignIdObject
        {
            get
            {
                return MyCampaignId;
            }

            set
            {
                MyCampaignId = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the namespace object.
        /// </summary>
        [IgnoreDataMember]
        public IPropertieBody NamespaceObject
        {
            get
            {
                return MyNamespace;
            }

            set
            {
                MyNamespace = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the uu id object.
        /// </summary>
        [IgnoreDataMember]
        public IPropertieBody UuIdObject
        {
            get
            {
                return MyUuId;
            }

            set
            {
                MyUuId = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the time stamp object.
        /// </summary>
        [IgnoreDataMember]
        public IPropertieBody TimeStampObject
        {
            get
            {
                return MyTimeStamp;
            }

            set
            {
                MyTimeStamp = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the tags object.
        /// </summary>
        [IgnoreDataMember]
        public IPropertieBody TagsObject
        {
            get
            {
                return MyTags;
            }

            set
            {
                MyTags = ToClass(value);
            }
        }

        PropertieBody ToClass(IPropertieBody iPropertieBody)
        {
            return (PropertieBody)iPropertieBody;
        }
    }
}
