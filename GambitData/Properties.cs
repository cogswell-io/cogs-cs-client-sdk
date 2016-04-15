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
