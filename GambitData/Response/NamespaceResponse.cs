namespace GambitData
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The NamespaceResponse
    /// </summary>
    [DataContract]
    public class NamespaceResponse
    {
        /// <summary>
        /// Gets or sets the Attributes
        /// </summary>
        [DataMember(Name = "attributes")]
        public IEnumerable<NamespaceAttribute> Attributes { get; set; }
    }
}
