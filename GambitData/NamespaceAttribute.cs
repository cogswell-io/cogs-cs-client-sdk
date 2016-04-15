namespace GambitData
{
    using System;
    using System.Runtime.Serialization;

    [DataContract(Name = "attributes")]
    public class NamespaceAttribute
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "data_type")]
        public string DataType { get; set; }

        [DataMember(Name = "core")]
        public bool Core { get; set; }

        [DataMember(Name = "ciid")]
        public bool CIID { get; set; }

        [DataMember(IsRequired=false)]
        public string Value { get; set; }
    }
}
