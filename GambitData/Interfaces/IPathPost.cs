namespace GambitData
{
    /// <summary>
    /// The PathPost interface.
    /// </summary>
    public interface IPathPost
    {
        /// <summary>
        /// Gets or sets the post object.
        /// </summary>
        IPathHttpMethod PostObject { get; set; }
    }
}
