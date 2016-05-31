namespace GambitData
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Class that stores information for namespace attributes
    /// </summary>
    [DataContract(Name = "attributes")]
    public class NamespaceAttribute
    {
        /// <summary>
        /// The name of the attribute
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The DataType of the attribute
        /// </summary>
        [DataMember(Name = "data_type")]
        public string DataType { get; set; }

        /// <summary>
        /// The Core of the attribute
        /// </summary>
        [DataMember(Name = "core")]
        public bool Core { get; set; }

        /// <summary>
        /// The CIID of the attribute
        /// </summary>
        [DataMember(Name = "ciid")]
        public bool CIID { get; set; }

        /// <summary>
        /// The Value of the attribute
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Value { get; set; }
    }
}
