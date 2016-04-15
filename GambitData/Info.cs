namespace GambitData
{
    using System;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;

    /// <summary>
    /// The info.
    /// </summary>
    [Serializable]
    [DataContract(Name = "Info")]
    [Export(typeof(IInfo))]
    public class Info : IInfo
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [DataMember(Name = "version")]
        public string Version { get; set; }
    }
}
