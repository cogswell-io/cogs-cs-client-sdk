namespace GambitData
{
    using System;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;

    /// <summary>
    /// The schema.
    /// </summary>
    [Serializable]
    [DataContract(Name = "Schema")]
    [Export(typeof(ISchema))]
    public class Schema : ISchema
    {
        /// <summary>
        /// Gets or sets the ref.
        /// </summary>
        [DataMember(Name = "ref")]
        public string Ref { get; set; }
    }
}
