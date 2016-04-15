namespace GambitData
{
    using System;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;

    /// <summary>
    /// The parameter.
    /// </summary>
    [Serializable]
    [DataContract(Name = "Parameter")]
    [Export(typeof(IPathHttpMethod))]
    public class Parameter : IParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        public Parameter()
        {
            MySchema = new Schema();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the in.
        /// </summary>
        [DataMember(Name = "in")]
        public string In { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the my schema.
        /// </summary>
        [DataMember(Name = "schema")]
        Schema MySchema { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether required.
        /// </summary>
        [DataMember(Name = "required")]
        public bool Required { get; set; }

        /// <summary>
        /// Gets or sets the schema object.
        /// </summary>
        [IgnoreDataMember]
        public ISchema SchemaObject
        {
            get
            {
                if (MySchema == null)
                {
                    MySchema = new Schema()
                                   {
                                       Ref = String.Empty
                                   };
                }

                return MySchema;
            }

            set
            {
                MySchema = ToClass(value);
            }
        }

        /// <summary>
        /// The to class.
        /// </summary>
        /// <param name="iSchema">
        /// The i schema.
        /// </param>
        /// <returns>
        /// The <see cref="Schema"/>.
        /// </returns>
        Schema ToClass(ISchema iSchema)
        {
            return (Schema)iSchema;
        }
    }
}
