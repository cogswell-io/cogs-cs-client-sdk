namespace GambitData
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Namespace schema details model for http responses
    /// </summary>
    [DataContract]
    public class NamespaceResponse
    {
        /// <summary>
        /// An enumeration of namespace attributes for the namespace response
        /// </summary>
        [DataMember(Name = "attributes")]
        public IEnumerable<NamespaceAttribute> Attributes { get; set; }
    }
}
