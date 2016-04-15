namespace GambitData
{
    /// <summary>
    /// The Properties interface.
    /// </summary>
    public interface IProperties
    {
        /// <summary>
        /// Gets or sets the client secret object.
        /// </summary>
        IPropertieBody ClientSecretObject { get; set; }

        /// <summary>
        /// Gets or sets the client salt object.
        /// </summary>
        IPropertieBody ClientSaltObject { get; set; }

        /// <summary>
        /// Gets or sets the error message object.
        /// </summary>
        IPropertieBody ErrorMessageObject { get; set; }

        /// <summary>
        /// Gets or sets the message object.
        /// </summary>
        IPropertieBody MessageObject { get; set; }

        /// <summary>
        /// Gets or sets the details object.
        /// </summary>
        IPropertieBody DetailsObject { get; set; }

        /// <summary>
        /// Gets or sets the event name object.
        /// </summary>
        IPropertieBody EventNameObject { get; set; }

        /// <summary>
        /// Gets or sets the access key object.
        /// </summary>
        IPropertieBody AccessKeyObject { get; set; }

        /// <summary>
        /// Gets or sets the attributes object.
        /// </summary>
        IPropertieBody AttributesObject { get; set; }

        /// <summary>
        /// Gets or sets the campaign id object.
        /// </summary>
        IPropertieBody CampaignIdObject { get; set; }

        /// <summary>
        /// Gets or sets the namespace object.
        /// </summary>
        IPropertieBody NamespaceObject { get; set; }

        /// <summary>
        /// Gets or sets the uu id object.
        /// </summary>
        IPropertieBody UuIdObject { get; set; }

        /// <summary>
        /// Gets or sets the time stamp object.
        /// </summary>
        IPropertieBody TimeStampObject { get; set; }

        /// <summary>
        /// Gets or sets the tags object.
        /// </summary>
        IPropertieBody TagsObject { get; set; }
    }
}
