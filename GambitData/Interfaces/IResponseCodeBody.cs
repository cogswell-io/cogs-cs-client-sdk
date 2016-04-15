namespace GambitData
{
    /// <summary>
    /// The ResponseCodeBody interface.
    /// </summary>
    public interface IResponseCodeBody
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the schema object.
        /// </summary>
        ISchema SchemaObject { get; set; }
    }
}
