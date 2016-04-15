namespace GambitData
{
    using System.Collections.Generic;

    /// <summary>
    /// The RootObject interface.
    /// </summary>
    public interface IRootObject
    {
        /// <summary>
        /// Gets or sets the paths object.
        /// </summary>
        IPaths PathsObject { get; set; }

        /// <summary>
        /// Gets or sets the info object.
        /// </summary>
        IInfo InfoObject { get; set; }

        /// <summary>
        /// Gets or sets the produces.
        /// </summary>
        IEnumerable<string> Produces { get; set; }

        /// <summary>
        /// Gets or sets the definitions object.
        /// </summary>
        IDefinitions DefinitionsObject { get; set; }

        /// <summary>
        /// Gets or sets the gambit.
        /// </summary>
        string Gambit { get; set; }
    }
}