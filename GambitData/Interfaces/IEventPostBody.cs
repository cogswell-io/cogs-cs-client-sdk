namespace GambitData
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// The EventPostBody interface.
    /// </summary>
    public interface IEventPostBody
    {
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        string[] Tags { get; set; }

        /// <summary>
        /// Gets or sets the client salt.
        /// </summary>
        string ClientSalt { get; set; }

        /// <summary>
        /// Gets or sets the event name.
        /// </summary>
        string EventName { get; set; }

        /// <summary>
        /// Gets or sets the access key.
        /// </summary>
        string AccessKey { get; set; }

        /// <summary>
        /// Gets or sets the campaign id.
        /// </summary>
        int CampaignId { get; set; }

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        Dictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        string Namespace { get; set; }

        /// <summary>
        /// The validate required proparties.
        /// </summary>
        void ValidateRequiredProparties();
    }
}