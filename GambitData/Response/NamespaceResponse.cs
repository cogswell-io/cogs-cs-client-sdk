namespace GambitData
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class NamespaceResponse
    {
        [DataMember(Name = "attributes")]
        public IEnumerable<NamespaceAttribute> Attributes { get; set; }

    }
}
