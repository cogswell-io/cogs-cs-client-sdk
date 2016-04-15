namespace GambitData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;

    /// <summary>
    /// The aviata api model.
    /// </summary>
    [Serializable]
    [DataContract(Name = "AviataApiModel")]
    [Export(typeof(IAviataApiModel))]
    public class AviataApiModel : IAviataApiModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AviataApiModel"/> class.
        /// </summary>
        public AviataApiModel()
        {
            MyProperties = new Properties();
        }

        /// <summary>
        /// Gets or sets the required.
        /// </summary>
        [DataMember(Name = "required")]
        public IEnumerable<string> Required { get; set; }

        /// <summary>
        /// Gets or sets the my properties.
        /// </summary>
        [DataMember(Name = "properties")]
        Properties MyProperties { get; set; }

        /// <summary>
        /// Gets or sets the properties object.
        /// </summary>
        [IgnoreDataMember]
        public IProperties PropertiesObject
        {
            get
            {
                return MyProperties;
            }

            set
            {
                MyProperties = ToClass(value);
            }
        }

        /// <summary>
        /// The to class.
        /// </summary>
        /// <param name="iProperties">
        /// The i properties.
        /// </param>
        /// <returns>
        /// The <see cref="Properties"/>.
        /// </returns>
        Properties ToClass(IProperties iProperties)
        {
            return (Properties)iProperties;
        }
    }
}
