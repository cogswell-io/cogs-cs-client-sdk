namespace GambitData
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The EventAttributes interface.
    /// </summary>
    public interface IEventAttributes
    {
        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        Dictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// The add attribute.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        void AddAttribute(string key, object value);

        /// <summary>
        /// The add atributes to request.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        void AddAtributesToRequest(ref string input);
    }
}