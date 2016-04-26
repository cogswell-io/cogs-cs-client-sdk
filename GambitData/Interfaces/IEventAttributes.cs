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
        /// A set of key-value attributes
        /// </summary>
        Dictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Adds a new attribute to the collection
        /// </summary>
        /// <param name="key">Key to be added</param>
        /// <param name="value">Value of the attribute</param>
        void AddAttribute(string key, object value);

        /// <summary>
        /// Adds an attribute to the request. Replaces the placeholder with the actual attributes
        /// </summary>
        /// <param name="input">The input to be replaced</param>
        void AddAtributesToRequest(ref string input);
    }
}