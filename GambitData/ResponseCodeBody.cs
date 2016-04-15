namespace GambitData
{
    using System;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;

    /// <summary>
    /// The response code body.
    /// </summary>
    [Serializable]
    [DataContract(Name = "ResponseCodeBody")]
    [Export(typeof(IResponseCodeBody))]
    public class ResponseCodeBody : IResponseCodeBody
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseCodeBody"/> class.
        /// </summary>
        public ResponseCodeBody()
        {
            MySchema = new Schema();
        }

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
        /// Gets or sets the schema object.
        /// </summary>
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
