namespace GambitData
{
    using System;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;

    /// <summary>
    /// The items.
    /// </summary>
    [Serializable]
    [DataContract(Name = "Items")]
    [Export(typeof(IItems))]
    public class Items : IItems
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
