namespace GambitData
{
    using System;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;

    /// <summary>
    /// The path post.
    /// </summary>
    [Serializable]
    [DataContract(Name = "PathPost")]
    [Export(typeof(IPathPost))]
    public class PathPost : IPathPost
    {
        public PathPost()
        {
            MyPost = new PathHttpMethod();
        }

        /// <summary>
        /// Gets or sets the my post.
        /// </summary>
        [DataMember(Name = "post")]
        PathHttpMethod MyPost { get; set; }

        /// <summary>
        /// Gets or sets the post object.
        /// </summary>
        [IgnoreDataMember]
        public IPathHttpMethod PostObject
        {
            get
            {
                return MyPost;
            }

            set
            {
                MyPost = ToClass(value);
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
