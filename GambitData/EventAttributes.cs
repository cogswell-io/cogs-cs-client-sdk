namespace GambitData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Holding the attributes for an event
    /// </summary>
    [DataContract]
    public class EventAttributes : IEventAttributes
    {
        /// <summary>
        /// Placeholder if there is no attributes for an event
        /// </summary>
        internal const string EventAttributesPlaceHolder = "ATTRIBUTES_PLACE_HOLDER";

        /// <summary>
        /// Initializes a new instance of the <see cref="EventAttributes"/> class.
        /// </summary>
        public EventAttributes()
        {
            Attributes = new Dictionary<string, object>();
        }

        /// <summary>
        /// A set of key-value attributes
        /// </summary>
        public Dictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Adds a new attribute to the collection
        /// </summary>
        /// <param name="key">Key to be added</param>
        /// <param name="value">Value of the attribute</param>
        public void AddAttribute(string key, object value)
        {
            this.Attributes.Add(key, value);
        }

        /// <summary>
        /// Adds an attribute to the request. Replaces the placeholder with the actual attributes
        /// </summary>
        /// <param name="input">The input to be replaced</param>
        public void AddAtributesToRequest(ref string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Missing data in input");
            }

            int count = 0;
            string json = "{";
            foreach (KeyValuePair<string, object> myItem in this.Attributes)
            {
                int isNumericCheck = 0;
                char numEscape = '"';
                if (int.TryParse(myItem.Value.ToString(), out isNumericCheck))
                {
                    numEscape = ' ';
                }

                json += "\"" + myItem.Key + "\":" + numEscape + myItem.Value + numEscape;
                if (count < this.Attributes.Count - 1)
                {
                    json += ",";
                }

                count++;
            }

            json += "}";
            input = input.Replace("\"" + EventAttributesPlaceHolder + "\"", json);
        }
    }
}
