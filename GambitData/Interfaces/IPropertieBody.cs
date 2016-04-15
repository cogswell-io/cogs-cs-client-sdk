namespace GambitData
{
    /// <summary>
    /// The PropertieBody interface.
    /// </summary>
    public interface IPropertieBody
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Gets or sets the items object.
        /// </summary>
        IItems ItemsObject { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }
    }
}
