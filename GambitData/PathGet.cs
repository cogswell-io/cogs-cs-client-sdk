namespace GambitData
{
    using System;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;

    /// <summary>
    /// The path get.
    /// </summary>
    [Serializable]
    [DataContract(Name = "PathGet")]
    [Export(typeof(IPathGet))]
    public class PathGet : IPathGet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PathGet"/> class.
        /// </summary>
        public PathGet()
        {
            MyGet = new PathHttpMethod();
        }

        /// <summary>
        /// Gets or sets the my get.
        /// </summary>
        [DataMember(Name = "get")]
        PathHttpMethod MyGet { get; set; }

        /// <summary>
        /// Gets or sets the get object.
        /// </summary>
        [IgnoreDataMember]
        public IPathHttpMethod GetObject
        {
            get
            {
                return MyGet;
            }

            set
            {
                MyGet = ToClass(value);
            }
        }

        /// <summary>
        /// The to class.
        /// </summary>
        /// <param name="iPathHttpMethod">
        /// The i path http method.
        /// </param>
        /// <returns>
        /// The <see cref="PathHttpMethod"/>.
        /// </returns>
        PathHttpMethod ToClass(IPathHttpMethod iPathHttpMethod)
        {
            return (PathHttpMethod)iPathHttpMethod;
        }
    }
}
