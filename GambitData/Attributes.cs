namespace GambitData
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The Attributes class used to set a group of custom attributes to an object
    /// </summary>
    [DataContract]
    public class Attributes
    {
        /// <summary>
        /// Gets or sets the IsActive attribute
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the Gender attribute
        /// </summary>
        public int Gender { get; set; }
        
        // What is this about?
        public int MyProperty { get; set; }
    }
}
