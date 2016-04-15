namespace GambitData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The event attributes.
    /// </summary>
    [DataContract]
    public class EventAttributes : IEventAttributes
    {
        /// <summary>
        /// The event attributes place holder.
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
        /// Gets or sets the attributes.
        /// </summary>
        public Dictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// The add attribute.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void AddAttribute(string key, object value)
        {
            this.Attributes.Add(key, value);
        }

        /// <summary>
        /// The add atributes to request.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
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
