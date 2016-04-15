namespace GambitData
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public class CiidObject
    {
        [DataMember(Name = "attributes")]
        public Dictionary<string, object> Attributes { get; set; }
    }
}
