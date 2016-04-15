namespace GambitData
{
    using System;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;

    /// <summary>
    /// The propertie body.
    /// </summary>
    [Serializable]
    [DataContract(Name = "PropertieBody")]
    [Export(typeof(IPropertieBody))]
    public class PropertieBody : IPropertieBody
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertieBody"/> class.
        /// </summary>
        public PropertieBody()
        {
            MyItems = new Items();
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the my items.
        /// </summary>
        [DataMember(Name = "items")]
        Items MyItems { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IItems ItemsObject 
        {
            get
            {
                return MyItems;
            }

            set
            {
                MyItems = ToClass(value);
            }
        }

        /// <summary>
        /// The to class.
        /// </summary>
        /// <param name="iItems">
        /// The i items.
        /// </param>
        /// <returns>
        /// The <see cref="Items"/>.
        /// </returns>
        Items ToClass(IItems iItems)
        {
            return (Items)iItems;
        }
    }
}
