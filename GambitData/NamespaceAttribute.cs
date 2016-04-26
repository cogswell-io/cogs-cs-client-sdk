namespace GambitData
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The Namespace attribute
    /// </summary>
    [DataContract(Name = "attributes")]
    public class NamespaceAttribute
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the DataType
        /// </summary>
        [DataMember(Name = "data_type")]
        public string DataType { get; set; }

        /// <summary>
        /// Gets or sets the Core
        /// </summary>
        [DataMember(Name = "core")]
        public bool Core { get; set; }

        /// <summary>
        /// Gets or sets the CIID
        /// </summary>
        [DataMember(Name = "ciid")]
        public bool CIID { get; set; }

        /// <summary>
        /// Gets or sets the Value
        /// </summary>
        [DataMember(IsRequired=false)]
        public string Value { get; set; }
    }
}
