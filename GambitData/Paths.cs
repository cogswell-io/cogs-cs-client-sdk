namespace GambitData
{
    using System;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;

    /// <summary>
    /// The paths.
    /// </summary>
    [Serializable]
    [DataContract(Name = "Paths")]
    [Export(typeof(IPaths))]
    public class Paths : IPaths
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Paths"/> class.
        /// </summary>
        public Paths()
        {
            MyApiDocs = new PathGet();
            MyClientSecret = new PathPost();
            MyEvent = new PathPost();
            MyRandomUuid = new PathPost();
        }

        /// <summary>
        /// Gets or sets the my api docs.
        /// </summary>
        [DataMember(Name = "/api-docs")]
        PathGet MyApiDocs { get; set; }

        /// <summary>
        /// Gets or sets the my client secret.
        /// </summary>
        [DataMember(Name = "/client_secret")]
        PathPost MyClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the my event.
        /// </summary>
        [DataMember(Name = "/event")]
        PathPost MyEvent { get; set; }

        /// <summary>
        /// Gets or sets the my random uuid.
        /// </summary>
        [DataMember(Name = "/random_uuid")]
        PathPost MyRandomUuid { get; set; }

        /// <summary>
        /// Gets or sets the api docs object.
        /// </summary>
        [IgnoreDataMember]
        public IPathGet ApiDocsObject
        {
            get
            {
                return MyApiDocs;
            }

            set
            {
                MyApiDocs = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the client secret object.
        /// </summary>
        [IgnoreDataMember]
        public IPathPost ClientSecretObject
        {
            get
            {
                return MyClientSecret;
            }

            set
            {
                MyClientSecret = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the event object.
        /// </summary>
        [IgnoreDataMember]
        public IPathPost EventObject
        {
            get
            {
                return MyEvent;
            }

            set
            {
                MyEvent = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the random uuid object.
        /// </summary>
        [IgnoreDataMember]
        public IPathPost RandomUuidObject
        {
            get
            {
                return MyRandomUuid;
            }

            set
            {
                MyRandomUuid = ToClass(value);
            }
        }

        /// <summary>
        /// The to class.
        /// </summary>
        /// <param name="iPathGet">
        /// The i path get.
        /// </param>
        /// <returns>
        /// The <see cref="PathGet"/>.
        /// </returns>
        PathGet ToClass(IPathGet iPathGet)
        {
            return (PathGet)iPathGet;
        }

        /// <summary>
        /// The to class.
        /// </summary>
        /// <param name="iPathPost">
        /// The i path post.
        /// </param>
        /// <returns>
        /// The <see cref="PathPost"/>.
        /// </returns>
        PathPost ToClass(IPathPost iPathPost)
        {
            return (PathPost)iPathPost;
        }
    }
}
