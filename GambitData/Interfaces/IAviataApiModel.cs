namespace GambitData
{
    using System.Collections.Generic;

    /// <summary>
    /// The AviataApiModel interface.
    /// </summary>
    public interface IAviataApiModel
    {
        /// <summary>
        /// Gets or sets the required.
        /// </summary>
        IEnumerable<string> Required { get; set; }

        /// <summary>
        /// Gets or sets the properties object.
        /// </summary>
        IProperties PropertiesObject { get; set; }
    }
}
