namespace GambitData
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for the EventPostBody
    /// </summary>
    public interface IEventModel
    {
        /// <summary>
        /// The event tags
        /// </summary>
        string[] Tags { get; set; }

        /// <summary>
        /// The Client Salt for the event
        /// </summary>
        string ClientSalt { get; set; }

        /// <summary>
        /// The name of the event
        /// </summary>
        string EventName { get; set; }

        /// <summary>
        /// The access key for the event
        /// </summary>
        string AccessKey { get; set; }

        /// <summary>
        /// The Campaing Id for the event
        /// </summary>
        int CampaignId { get; set; }

        /// <summary>
        /// The timestamp for the event as <see cref="string"/>
        /// ISO-8601 <example>2016-01-15T11:54+0000</example>
        /// </summary>
        string Timestamp { get; set; }

        /// <summary>
        /// A dictionary that holds the <see cref="NamespaceAttribute"/> attributes 
        /// mapped as <see cref="string"/> name and <see cref="object"/> value pairs
        /// </summary>
        IDictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// A dictionary that holds only the PrimaryKey attributes for quicker comparison
        /// </summary>
        IDictionary<string, object> PrimaryKeyAttributes { get; set; }

        /// <summary>
        /// The namespace for the event
        /// </summary>
        string Namespace { get; set; }

        /// <summary>
        /// Validates the properties of request.
        /// Used to assert that all required properties are set
        /// </summary>
        void ValidateRequiredProperties();

        /// <summary>
        /// Check if two Events have the same name, namespace and primary key attributes
        /// </summary>
        /// <param name="other">The event to compare equality to</param>
        /// <returns>True if they all of the above conditions match</returns>
        bool Equals(IEventModel other);
    }
}