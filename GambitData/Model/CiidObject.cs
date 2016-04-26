namespace GambitData
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The CIID object
    /// </summary>
    public class CiidObject
    {
        /// <summary>
        /// Gets or sets the attributes
        /// </summary>
        [DataMember(Name = "attributes")]
        public Dictionary<string, object> Attributes { get; set; }
    }
}
