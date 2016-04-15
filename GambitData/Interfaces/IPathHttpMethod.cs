namespace GambitData
{
    using System.Collections.Generic;

    /// <summary>
    /// The PathHttpMethod interface.
    /// </summary>
    public interface IPathHttpMethod
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the parameters object list.
        /// </summary>
        IList<IParameter> ParametersObjectList { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        string Summary { get; set; }

        /// <summary>
        /// Gets or sets the responses object.
        /// </summary>
        IResponses ResponsesObject { get; set; }
    }
}
